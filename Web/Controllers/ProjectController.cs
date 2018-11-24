using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service.Interfaces;
using Service.Services;
using Web.Models;
using Data;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        private Context db = new Context();
        private IClientService clientService = new ClientService();
        private ISkillService skillService = new SkillService();
        private IProjectService projectService = new ProjectService();
        private IProjectSkillService projectSkillService = new ProjectSkillService();
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/projects").Result;

            if (response.IsSuccessStatusCode)
            {

                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<ProjectViewModel>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View(ViewBag.result);
        }

        [HttpPost]
        public ActionResult Archive(String hiddenId)
        {
            int id = Int32.Parse(hiddenId);
            ProjectViewModel projectViewModel = null;
            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client2.GetAsync("Map-JavaEE-web/MAP/projects?projectId=" + id).Result;
            ViewBag.result = response.Content.ReadAsAsync<ProjectViewModel>().Result;
            projectViewModel = ViewBag.result;


            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.PostAsJsonAsync<ProjectViewModel>("Map-JavaEE-web/MAP/projects/ArchiveProject", projectViewModel)
                .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/projects?projectId=" + id).Result;
            ViewBag.result = response.Content.ReadAsAsync<ProjectViewModel>().Result;
            var res = db.projectskills
                .Join(db.skills, ps => ps.idSkill, s => s.IdSkill, (ps, s) => new { ps, s })
                .Join(db.projects, ppc => ppc.ps.idProject, p => p.id, (ppc, p) => new { ppc, p })
                .Where(m => m.p.id.Equals(120))
                .Select(m => new
                {
                    name = m.ppc.s.NameSkill,
                    percent = m.ppc.ps.percentage

                }).ToList();
            List<KeyValuePair<string, int>> listSkill = new List<KeyValuePair<string, int>>();
            foreach (var item in res)
            {
                listSkill.Add(new KeyValuePair<string, int>(item.name, item.percent));
                var name = item.name;
                var idSkill = item.percent;

            }
            ViewBag.Skills = listSkill;
            return View(ViewBag.result);
        }


        public ActionResult Create()
        {
            initDropList();
            FillEnumDropDownList();
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProjectViewModel projectViewModel, SkillViewModel skillViewModel, String tags, String btn)
        {
            initDropList();
            FillEnumDropDownList();
            projectViewModel.totalNumberResource = 0;
            projectViewModel.levioNumberResource = 0;
            skill skillDomain = new skill();
            List<string> listTags = tags.Split(',').ToList();
            List<SkillViewModel> listSkills = new List<SkillViewModel>();
            string clientId = Request.Form["CLIENT"].ToString();
            string projectType = Request.Form["TypeProject"].ToString();



            projectViewModel.projectType = projectType;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            if (btn != null && btn == "Next Step")
            {
                Client.PostAsJsonAsync<ProjectViewModel>(
                        "Map-JavaEE-web/MAP/projects?idClient=" + Int32.Parse(clientId), projectViewModel)
                    .ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

                foreach (var tag in listTags)
                {
                    skillViewModel.NameSkill = tag;
                    skillDomain.NameSkill = skillViewModel.NameSkill;
                    skillService.Add(skillDomain);
                    skillService.Commit();
                    listSkills.Add(new SkillViewModel(skillDomain.IdSkill, skillDomain.NameSkill));

                }
                var i1 = db.projects.OrderByDescending(u => u.id).FirstOrDefault();

                return RedirectToAction("Skills", new { serializedModel = JsonConvert.SerializeObject(listSkills), id = i1.id });
            }

            return View();
        }


        public ActionResult Skills(string serializedModel, int id)
        {
            List<SkillViewModel> listSkill = JsonConvert.DeserializeObject<List<SkillViewModel>>(serializedModel);
            ViewBag.TAGS = listSkill;
            return View("Skills");
        }

        [HttpPost]
        public ActionResult Skills(string serializedModel, int id, FormCollection form)
        {
            skill skillDomain = new skill();
            project projectDomain = projectService.GetById(id);
            List<SkillViewModel> listSkill = JsonConvert.DeserializeObject<List<SkillViewModel>>(serializedModel);
            ViewBag.TAGS = listSkill;

            foreach (var skill in listSkill)
            {
                skillDomain.IdSkill = skill.IdSkill;
                projectskill projectSkillDomain = new projectskill
                {
                    idSkill = skillDomain.IdSkill,
                    idProject = projectDomain.id,
                    percentage = Int32.Parse(form.Get("percent+" + skill.IdSkill))
                };
                projectSkillService.Add(projectSkillDomain);
                projectSkillService.Commit();
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            initDropList();
            FillEnumDropDownList();

            string skills = null;
            string delimiter = ",";

            ProjectViewModel projectViewModel = null;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080/");
            var responseTask = Client.GetAsync("Map-JavaEE-web/MAP/projects?projectId=" + id.ToString());
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ProjectViewModel>();
                readTask.Wait();
                projectViewModel = readTask.Result;
            }
            List<String> listSkills = new List<string>();
            var res = db.projectskills
                .Join(db.skills, ps => ps.idSkill, s => s.IdSkill, (ps, s) => new { ps, s })
                .Join(db.projects, ppc => ppc.ps.idProject, p => p.id, (ppc, p) => new { ppc, p })
                .Where(m => m.p.id.Equals(id))
                .Select(m => new
                {
                    name = m.ppc.s.NameSkill,
                    percent = m.ppc.ps.percentage

                }).ToList();

            foreach (var item in res)
            {
                listSkills.Add(item.name);

            }
            skills = String.Join(delimiter, listSkills);
            ViewBag.Skills = skills;
            ViewBag.CLIENT = new SelectList(db.people, "id", "nameSociety", projectViewModel.clientId.id);
            return View(projectViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProjectViewModel projectViewModel, string tags, string btn)
        {
            if (btn != null && btn == "Next Step")
            {
                using (var client = new HttpClient())
                {
                    String clientId = Request.Form["CLIENT"].ToString();
                    string projectType = Request.Form["TypeProject"].ToString();
                    projectViewModel.projectType = projectType;
                    person person = clientService.GetById(Int32.Parse(clientId));
                    projectViewModel.clientId = person;
                    client.BaseAddress = new Uri("http://127.0.0.1:18080/");
                    var putTask =
                        client.PutAsJsonAsync<ProjectViewModel>("Map-JavaEE-web/MAP/projects", projectViewModel);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                }
                FillEnumDropDownList();
                ViewBag.CLIENT = new SelectList(db.people, "id", "nameSociety", projectViewModel.clientId.id);

                //list value of tags from view 
                List<string> listTagsFromView = tags.Split(',').ToList();
                //list of skills of project from db
                List<skill> listSkillsFromDb = new List<skill>();
                //List qui sera envoyer à la vue EditSkills avec liste des skills ajouter
                List<SkillViewModel> listSkillViewModel = new List<SkillViewModel>();

                skill skillDomain = new skill();
                projectskill projectSkill = new projectskill();
                var res = db.projectskills
                    .Join(db.skills, ps => ps.idSkill, s => s.IdSkill, (ps, s) => new { ps, s })
                    .Join(db.projects, ppc => ppc.ps.idProject, p => p.id, (ppc, p) => new { ppc, p })
                    .Where(m => m.p.id.Equals(projectViewModel.id))
                    .Select(m => new
                    {
                        id = m.ppc.s.IdSkill,
                        name = m.ppc.s.NameSkill,
                        percent = m.ppc.ps.percentage

                    }).ToList();

                foreach (var item in res)
                {
                    listSkillsFromDb.Add(new skill(item.id, item.name));

                }

                List<string> nameSkills = listSkillsFromDb.Select(o => o.NameSkill).ToList();

                foreach (var tag in listTagsFromView)
                {
                    if (!(nameSkills.Contains(tag)))
                    {

                        skillDomain.NameSkill = tag;
                        skillService.Add(skillDomain);
                        skillService.Commit();
                        listSkillViewModel.Add(new SkillViewModel(skillDomain.IdSkill, skillDomain.NameSkill));
                    }
                }
                foreach (var skill in listSkillsFromDb)
                {
                    if (!(listTagsFromView.Contains(skill.NameSkill)))
                    {
                        projectSkill = projectSkillService.GetMany().Where(a => a.idProject == projectViewModel.id)
                            .Where(b => b.idSkill == skill.IdSkill).FirstOrDefault();
                        projectSkillService.Delete(projectSkill);

                        projectSkillService.Commit();

                        skillDomain = skillService.GetById(skill.IdSkill);
                        skillService.Delete(skillDomain);

                        skillService.Commit();
                    }
                    else
                    {
                        listSkillViewModel.Add(new SkillViewModel(skill.IdSkill, skill.NameSkill));
                    }
                }

                return RedirectToAction("EditSkills", new { serializedModel = JsonConvert.SerializeObject(listSkillViewModel), id = projectViewModel.id });
            }
            return View(projectViewModel);
        }

        public ActionResult EditSkills(string serializedModel, int id, FormCollection form, string percent)
        {
            List<SkillViewModel> listSkill = JsonConvert.DeserializeObject<List<SkillViewModel>>(serializedModel);
            ViewBag.TAGS = listSkill;
            projectskill projectSkill = new projectskill();
            List<ProjectSkillViewModel> listPS = new List<ProjectSkillViewModel>();

            foreach (var skill in listSkill)
            {
                projectSkill = projectSkillService.GetMany().Where(a => a.idProject == id)
                   .Where(b => b.idSkill == skill.IdSkill).FirstOrDefault();
                if (projectSkill != null)
                {
                    listPS.Add(new ProjectSkillViewModel(projectSkill.idProject, projectSkill.idSkill, projectSkill.percentage));
                }
            }
            ViewBag.ProjectSkills = listPS;
            return View("EditSkills");
        }
        [HttpPost]
        public ActionResult EditSkills(string serializedModel, int id, FormCollection form)
        {
            skill skillDomain = new skill();
            project projectDomain = projectService.GetById(id);
            List<SkillViewModel> listSkill = JsonConvert.DeserializeObject<List<SkillViewModel>>(serializedModel);
            ViewBag.TAGS = listSkill;
            //First delete after add
            foreach (var skill in listSkill)
            {
                //Delete
                projectskill projectSkillDomainDelete = projectSkillService.GetMany().Where(a => a.idProject == id)
                    .Where(b => b.idSkill == skill.IdSkill).FirstOrDefault();
                if (projectSkillDomainDelete != null)
                {
                    projectSkillService.Delete(projectSkillDomainDelete);
                    projectSkillService.Commit();
                }
                //Add
                skillDomain.IdSkill = skill.IdSkill;
                projectskill projectSkillDomain = new projectskill();
                projectSkillDomain.idSkill = skillDomain.IdSkill;
                projectSkillDomain.idProject = projectDomain.id;
                projectSkillDomain.percentage = Int32.Parse(form.Get(skill.NameSkill));
                projectSkillService.Add(projectSkillDomain);
                projectSkillService.Commit();
            }
            return RedirectToAction("Index");
        }

        public void FillEnumDropDownList()
        {
            var list = new List<SelectListItem>

            {
                new SelectListItem{ Text="New project", Value = "newProject" },
                new SelectListItem{ Text="Project in progress", Value = "projectInProgress" },
                new SelectListItem{ Text="Completed project", Value = "completedProject"},
            };
            ViewBag.TypeProject = list;
        }

        public void initDropList()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://127.0.0.1:18080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("Map-JavaEE-web/MAP/clients").Result;
            ViewBag.CLIENT = response.Content.ReadAsAsync<IEnumerable<ClientViewModel>>().Result;
        }
    }
}
