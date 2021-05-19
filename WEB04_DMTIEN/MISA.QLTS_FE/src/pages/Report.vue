<template>
  <div id="report">
    <!-- header -->
    <Header :Route="reportRoute" />
  </div>
</template>

<script>
import Header from "../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    reportRoute() {
      return this.$store.getters.routeFilter("Báo cáo");
    },
  },
};
</script>

<style></style>
