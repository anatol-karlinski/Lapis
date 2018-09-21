<template>
  <div>
    <div
      v-if="alert.message"
      :class="`alert ${alert.type}`">{{ alert.message }}</div>
    <router-view/>
    <router-link to="/register">
      Register
    </router-link>
    <router-link to="/login">
      Login
    </router-link>
    <router-link to="/auth">
      Auth test
    </router-link>
  </div>
</template>
<script>
import { mapState, mapActions } from 'vuex';

export default {
  name: 'App',
  computed: {
    ...mapState({
      alert: state => state.alert
    })
  },
  watch: {
    // $route(to, from) {
    $route() {
      this.clearAlert();
    }
  },
  methods: {
    ...mapActions({
      clearAlert: 'alert/clear'
    })
  }
};
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
a {
  margin: 10px;
}
</style>
