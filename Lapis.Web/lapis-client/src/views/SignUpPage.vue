<template>
  <div class="t-flex t-flex-col t-relative t-m-auto t-mt-10 t-w-1/5">
    <h3>
      Rejestracja
    </h3>
    <br>
    <div>Username:</div>
    <input
      v-model="user.username"
      type="text">
    <br >
    Password:
    <input
      v-model="user.password"
      type="password">
    <button @click="register(user)">Register</button>
  </div>
</template>


<script>
import { mapActions } from 'vuex';

export default {
  name: 'SignUpPage',
  data() {
    return {
      user: {
        username: '',
        password: ''
      }
    };
  },
  methods: {
    ...mapActions({
      register: 'authentication/register'
    })
  }
};
</script>

<style>
</style>
