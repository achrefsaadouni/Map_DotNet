(function() {
    var uP  = function(url) {
      var sU = url.split(":");
      var ext = sU[0];
      ext = (ext == "http" || ext == "https" ? ext : "http"); //DETERMINE URL PROTOCOL
      var uri = (sU[1] ? sU[1] : sU[0]);
      var s_U = uri.split("/");
      var dom = (s_U[0] == "" && s_U[1] == "" ? s_U[2] : s_U[0]); //DETERMING DOMAIN NAME AND SUBDOMAIN
      return [ext, dom];
    };
    var fI = function(uP) {
      return (uP[0] + "://" + uP[1] + "/favicon.ico");
    };
    var getFavicon = function(url) {
      return fI(uP(url));
    };
    var d = function(p,f) {
      window[p] = window[p] ? window[p] : f;
    };
    //REGISTER GLOBALS
    d("getFavicon", getFavicon);
    d("gF", getFavicon);
    d("_gF", getFavicon);
})();
