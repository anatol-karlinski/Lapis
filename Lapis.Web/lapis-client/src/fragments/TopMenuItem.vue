<template>
  <router-link
    v-if="shouldBeDisplayed"
    :to="route"
    class="t-no-underline t-text-grey-lightest t-m-2 t-text-sm">
    {{ text }}
  </router-link>
</template>

<script>
// import { mapState } from 'vuex';

export default {
  name: 'TopMenuItem',
  props: {
    text: { type: String, required: true },
    route: { type: String, required: true },
    authorizationRequired: { type: Boolean, required: true }
  },
  computed: {
    shouldBeDisplayed: function() {
      console.log(
        this.authorizationRequired
          ? this.$store.state.authentication.status.loggedIn
          : true
      );

      return this.authorizationRequired
        ? this.$store.state.authentication.status.loggedIn
        : true;
    }
  }
};
</script>
