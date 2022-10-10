const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    //target: "https://localhost:5001",
    target: "https://localhost:7235",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
