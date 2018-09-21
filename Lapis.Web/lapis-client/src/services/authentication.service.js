import config from 'config';
import Axios from 'axios';

export const authenticationService = {
  login,
  logout,
  register,
  getAuthHeader
};

function login(username, password) {
  const requestParams = {
    method: 'post',
    url: config.apiUrl + '/login',
    data: {
      Username: username,
      Password: password
    }
  };

  return Axios(requestParams)
    .then(handleResponse)
    .then(user => {
      if (user.token) {
        localStorage.setItem('user', JSON.stringify(user));
      }

      return user;
    });
}

function logout() {
  localStorage.removeItem('user');
}

function register(user) {
  const requestParams = {
    method: 'post',
    url: config.apiUrl + '/register',
    data: user
  };

  return Axios(requestParams)
    .then(handleResponse)
    .catch(handleError)
    .then(() => {
      return user;
    });
}

function handleError(error) {
  if (error.request.status === 401) {
    logout();
    location.reload(true);
  }

  return Promise.reject(error);
}

function handleResponse(response) {
  if (!response) return Promise.reject('No valid response form server.');

  if (!response.data) return null;

  if (typeof response.data === 'string') return JSON.parse(response.data);

  return response.data;
}

function getAuthHeader() {
  let user = JSON.parse(localStorage.getItem('user'));

  if (user && user.token) {
    return { Authorization: 'Bearer ' + user.token };
  } else {
    return {};
  }
}
