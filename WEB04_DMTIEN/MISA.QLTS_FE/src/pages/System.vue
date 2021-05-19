<template>
  <div id="system">
    <!-- header -->
    <Header :Route="systemRoute" />
  </div>
</template>

<script>
import Header from "../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    systemRoute() {
      return this.$store.getters.routeFilter("Hệ thống");
    },
  },
};
</script>

<style></style>
