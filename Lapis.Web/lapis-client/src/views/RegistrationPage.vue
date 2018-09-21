<template>
  <div class="t-flex t-flex-col t-relative t-m-auto t-mt-10 t-w-1/5">
    <div>Username:</div>
    <input
      v-model="username"
      type="text">
    <br >
    Password:
    <input
      v-model="password"
      type="password">
    <button @click="register">Register</button>
  </div>
</template>


<script>
import { authenticationService } from '../services';

export default {
  name: 'RegistrationPage',
  data() {
    return {
      username: '',
      password: ''
    };
  },
  methods: {
    register() {
      authenticationService
        .register({
          username: this.username,
          password: this.password
        })
        .then(user => {
          console.log(user);

          return true;
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>

<style>
</style>
