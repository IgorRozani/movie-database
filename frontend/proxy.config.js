const proxy = [
    {
      context: '/api',
      target: 'http://localhost:64281',
      pathRewrite: { '^/api': '/api' }
    }
  ];
  module.exports = proxy;