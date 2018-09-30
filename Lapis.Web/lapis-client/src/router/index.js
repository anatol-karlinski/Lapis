import Vue from 'vue';
import Router from 'vue-router';

import SignUpPage from '@/views/SignUpPage';
import SignInPage from '@/views/SignInPage';
import LandingPage from '@/views/LandingPage';
import DashboardPage from '@/views/DashboardPage';

Vue.use(Router);

export const router = new Router({
  mode: 'history',
  routes: [
    { name: 'signup', path: '/signup', component: SignUpPage },
    { name: 'signin', path: '/signin', component: SignInPage },
    { name: 'dashboard', path: '/dashboard', component: DashboardPage },
    { name: 'landing', path: '/', component: LandingPage },
    { path: '*', redirect: '/' }
  ]
});

const publicPages = ['signup', 'signin', 'landing'];

router.beforeEach((to, from, next) => {
  const authRequired = !publicPages.includes(to.name);
  const loggedIn = localStorage.getItem('user');

  if (authRequired && !loggedIn) {
    return next('/landing');
  }

  next();
});
