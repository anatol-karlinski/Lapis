import { authenticationService } from '../services';
import { router } from '../router';

const user = JSON.parse(localStorage.getItem('user'));
const state = user
  ? { status: { loggedIn: true }, user }
  : { status: {}, user: null };

const actions = {
  login({ dispatch, commit }, { username, password }) {
    commit('loginRequest', { username });

    authenticationService
      .login(username, password)
      .then(u => {
        commit('loginSuccess', u);
        router.push('/');
      })
      .catch(error => {
        const message = error.response.data.message
          ? error.response.data.message
          : error;
        commit('loginFailure', message);
        dispatch('alert/error', message, { root: true });
      });
  },
  logout({ commit }) {
    authenticationService.logout();
    commit('logout');
  },
  register({ dispatch, commit }, passedUser) {
    commit('registerRequest', passedUser);

    authenticationService
      .register(passedUser)
      .then(u => {
        commit('registerSuccess', u);
        router.push('/login');
        setTimeout(() => {
          dispatch('alert/success', 'Registration successful', {
            root: true
          });
        });
      })
      .catch(error => {
        const message = error.response.data.message
          ? error.response.data.message
          : error;
        commit('registerFailure', message);
        dispatch('alert/error', message, { root: true });
      });
  }
};

const mutations = {
  loginRequest(state, passedUser) {
    state.status = { loggingIn: true };
    state.user = passedUser;
  },
  loginSuccess(state, passedUser) {
    state.status = { loggedIn: true };
    state.user = passedUser;
  },
  loginFailure(state) {
    state.status = {};
    state.user = null;
  },
  logout(state) {
    state.status = {};
    state.user = null;
  },
  registerRequest(state) {
    state.status = { registering: true };
  },
  registerSuccess(state) {
    state.status = {};
  },
  registerFailure(state) {
    state.status = {};
  }
};

export const authentication = {
  namespaced: true,
  state,
  actions,
  mutations
};
