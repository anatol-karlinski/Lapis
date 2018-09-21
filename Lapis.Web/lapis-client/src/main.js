import Vue from 'vue';
import Axios from 'axios';
import App from './App.vue';

import { router } from './router';
import { store } from './store';

import '@/assets/styles/tailwind-compiled.css';
import '@/assets/styles/tailwind-custom.css';

Vue.config.productionTip = false;
Vue.prototype.$http = Axios;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app');
