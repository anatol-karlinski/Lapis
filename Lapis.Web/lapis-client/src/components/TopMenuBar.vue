<template>
  <div
    class="t-flex t-relative t-w-full t-bg-grey-darkest t-text-grey-lightest">
    <top-menu-item
      :text="`Rejestracja`"
      :route="`signup`"
      :authorization-required="false"
      />
    <top-menu-item
      :text="`Login`"
      :route="`signin`"
      :authorization-required="false"
      />
    <top-menu-item
      :text="`Strona gówna`"
      :route="`landing`"
      :authorization-required="false"
      />
    <top-menu-item
      :text="`Strona gówna`"
      :route="`dashboard`"
      :authorization-required="true"
      />
    <div class="t-m-2 t-absolute t-pin-r t-text-sm">
      {{ userLogedIn ? "Logged in" : "Not logged in" }}
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex';
import TopMenuItem from '@/fragments/TopMenuItem';

export default {
  name: 'TopMenuBar',
  components: {
    TopMenuItem
  },
  computed: {
    ...mapState({
      userLogedIn: state => state.status
    })
  }
};
</script>
