<template>
  <div id="assets">
    <!-- header -->
    <Header :Route="assetsRoute" />

    <router-view></router-view>
  </div>
</template>

<script>
import Header from "../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    assetsRoute() {
      return this.$store.getters.routeFilter("Tài sản");
    },
  },
};
</script>

<style></style>
