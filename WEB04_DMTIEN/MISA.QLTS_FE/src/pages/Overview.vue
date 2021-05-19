<template>
  <div id="overview">
    <!-- header -->
    <Header :Route="overviewRoute" />
  </div>
</template>

<script>
import Header from "../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    overviewRoute() {
      return this.$store.getters.routeFilter("Tổng quan");
    },
  },
};
</script>

<style></style>
