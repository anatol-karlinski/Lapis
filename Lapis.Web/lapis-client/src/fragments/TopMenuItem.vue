<template>
  <router-link
    v-if="shouldBeDisplayed"
    :to="route"
    class="t-no-underline t-text-grey-lightest t-m-2 t-text-sm">
    {{ text }}
  </router-link>
</template>

<script>
export default {
  name: 'TopMenuItem',
  props: {
    text: { type: String, required: true },
    route: { type: String, required: true },
    showWhenLoggedIn: { type: Boolean, default: true },
    showWhenNotLoggedIn: { type: Boolean, default: true }
  },
  computed: {
    shouldBeDisplayed: function() {
      let loggedIn = this.$store.state.authentication.status.loggedIn;

      return loggedIn ? this.showWhenLoggedIn : this.showWhenNotLoggedIn;
    }
  }
};
</script>
