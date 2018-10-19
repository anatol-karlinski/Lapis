<template>
  <div
    class="t-flex t-relative t-w-full t-bg-grey-darkest t-text-grey-lightest">
    <top-menu-item
      :text="`Strona gówna`"
      :route="`landing`"
      :show-when-not-logged-in="true"
      :show-when-logged-in="false"
      />
    <top-menu-item
      :wrapper-classes="`t-text-red`"
      :text="`Strona gówna`"
      :route="`dashboard`"
      :show-when-not-logged-in="false"
      :show-when-logged-in="true"
      />
    <top-menu-item
      :text="`Rejestracja`"
      :route="`signup`"
      :show-when-not-logged-in="true"
      :show-when-logged-in="false"
      />
    <top-menu-item
      :text="`Login`"
      :route="`signin`"
      :show-when-not-logged-in="true"
      :show-when-logged-in="false"
      />
    <top-menu-item
      :text="`Logout`"
      :show-when-not-logged-in="false"
      :show-when-logged-in="true"
      :wrapper-classes="`t-absolute t-pin-r`"
      @click.native="logout"
      />
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import TopMenuItem from '@/components/fragments/TopMenuItem';

export default {
  name: 'TopMenuBar',
  components: {
    TopMenuItem
  },
  // computed: {
  //   ...mapState({
  //     userLogedIn: state => state.authentication.status
  //   })
  // },
  methods: {
    ...mapActions({
      logout: 'authentication/logout'
    })
  }
};
</script>
