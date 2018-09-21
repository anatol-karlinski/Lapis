<template>
  <div>
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
export default {
  name: 'App'
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
