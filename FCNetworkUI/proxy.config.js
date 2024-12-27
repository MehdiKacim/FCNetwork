//http://localhost:5148/
const TARGET = "http://localhost:5148";
//const TARGET = "https://localhost:7002"
const PROXY_CONFIG = {
  "/api/user": {
    target:  TARGET,
    secure: false,
    changeOrigin: true,
    pathRewrite: {
      "^/api/user": "/User"
    }
  },
  "/api/device": {
    target:  TARGET,
    secure: false,
    changeOrigin: true,
    pathRewrite: {
      "^/api/device": "/Device"
    }
  },
};

module.exports = PROXY_CONFIG;

