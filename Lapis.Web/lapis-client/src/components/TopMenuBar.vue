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
