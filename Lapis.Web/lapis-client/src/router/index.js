import Vue from 'vue';
import Router from 'vue-router';

import RegistrationPage from '../views/RegistrationPage';
import LoginPage from '../views/LoginPage';
import AuthTest from '../views/AuthTestPage';

Vue.use(Router);

export const router = new Router({
  mode: 'history',
  routes: [
    { path: '/register', component: RegistrationPage },
    { path: '/login', component: LoginPage },
    { path: '/auth', component: AuthTest },
    { path: '/', component: RegistrationPage },
    { path: '*', redirect: '/' }
  ]
});

router.beforeEach((to, from, next) => {
  const publicPages = ['/login', '/register'];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem('user');

  if (authRequired && !loggedIn) {
    return next('/login');
  }

  next();
});
