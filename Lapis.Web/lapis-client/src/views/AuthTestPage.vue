<template>
  <div>
    <button @click="testAuth"> Check auth </button>
    <div
      id="authCheck"
      :v-bind="authStatus"/>
  </div>
</template>

<script>
import config from 'config';
import { authenticationService } from '../services';

export default {
  name: 'AuthTest',
  data() {
    return {
      authStatus: ''
    };
  },
  methods: {
    testAuth() {
      const requestParams = {
        method: 'get',
        url: config.apiUrl + '/authTest',
        headers: authenticationService.getAuthHeader()
      };

      this.$http(requestParams)
        .then(response => {
          /* eslint-disable */
          console.log(response);
        })
        .catch(error => {
          /* eslint-disable */
          console.log(error);
        });
    }
  }
};
</script>

<style>
</style>
