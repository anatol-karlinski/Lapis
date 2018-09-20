import Vue from 'vue';
import Vuex from 'vuex';

import { alert } from './alert.module';

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    alert
  }
});

export default store;
