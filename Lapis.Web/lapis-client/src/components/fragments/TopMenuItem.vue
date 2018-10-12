<template>
  <div
    v-if="shouldBeDisplayed"
    :class="`${wrapperClasses}`"
    class="t-m-2">
    <router-link
      :to="route"
      class="t-no-underline t-text-grey-lightest t-text-sm">
      {{ text }}
    </router-link>
  </div>
</template>

<script>
export default {
  name: 'TopMenuItem',
  props: {
    text: { type: String, required: true },
    route: { type: String, required: false, default: '#' },
    showWhenLoggedIn: { type: Boolean, default: true },
    showWhenNotLoggedIn: { type: Boolean, default: true }
  },
  computed: {
    shouldBeDisplayed: function() {
      let loggedIn = this.$store.state.authentication.status.loggedIn;

      return loggedIn ? this.showWhenLoggedIn : this.showWhenNotLoggedIn;
    },
    routeWasPassed: function() {
      return (
        typeof this.route != 'undefined' &&
        this.route != void 0 &&
        this.route != ''
      );
    }
  }
};
</script>
