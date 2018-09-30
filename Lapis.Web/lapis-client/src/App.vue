<template>
  <div class="t-flex t-flex-col t-absolute t-w-screen t-h-screen t-antialiased">
    <div
      class=
        "t-flex t-relative t-w-full
        t-bg-grey-darkest t-text-grey-lightest">
      <div
        v-if="alert.message"
        :class="`alert ${alert.type}`">{{ alert.message }}</div>
      <router-link
        v-for="item in menuItems"
        :key="item.text"
        :to="item.route"
        class="t-no-underline t-text-grey-lightest t-m-2 t-text-sm">
        {{ item.text }}
      </router-link>
      <div class="app-top-menu-item t-m-2 t-absolute t-pin-r t-text-sm">
        {{ status ? "Logged in" : "Not logged in" }}
      </div>
    </div>
    <div class="t-flex t-relative t-w-full t-h-full t-justify-center t-align-center">
      <div class="t-flex t-relative t-w-9/10">
        <router-view/>
      </div>
    </div>
  </div>
</template>
<script>
import { mapState, mapActions } from 'vuex';

export default {
  name: 'App',
  data() {
    return {
      menuItems: [
        { route: '/register', text: 'Register' },
        { route: '/login', text: 'Login' },
        { route: '/auth', text: 'Auth test' }
      ]
    };
  },
  computed: {
    ...mapState({
      alert: state => state.alert,
      status: state => state.status
    })
  },
  watch: {
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
</style>
