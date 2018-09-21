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
    <button @click="handleLogin">Login</button>
  </div>
</template>
<script>
import { mapActions } from 'vuex';

export default {
  name: 'LoginPage',
  data() {
    return {
      username: '',
      password: '',
      submitted: false
    };
  },
  methods: {
    ...mapActions('authentication', ['login', 'logout']),
    handleLogin() {
      this.submitted = true;
      const { username, password } = this;
      if (username && password) {
        this.login({ username, password });
      }
    }
  }
};
</script>

<style>
</style>
