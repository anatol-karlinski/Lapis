<template>
  <div class="t-flex t-flex-col t-absolute t-w-screen t-h-screen t-antialiased">
    <top-menu-bar/>
    <div class="t-flex t-relative t-w-full t-h-full t-justify-center t-align-center">
      <div class="t-flex t-flex-row t-relative t-justify-center t-w-9/10">
        <div
          v-if="alert.message !== null"
          class="t-flex t-justify-center t-my-2">{{ alert.message }}</div>
        <router-view/>
      </div>
    </div>
  </div>
</template>
<script>
import { mapState, mapActions } from 'vuex';
import TopMenuBar from '@/components/composite/TopMenuBar';

export default {
  name: 'App',
  components: {
    TopMenuBar
  },
  computed: {
    ...mapState({
      alert: state => state.alert,
      status: state => state.authentication.status
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
