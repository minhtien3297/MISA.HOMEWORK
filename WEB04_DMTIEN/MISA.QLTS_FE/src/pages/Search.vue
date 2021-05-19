<template>
  <div id="search">
    <!-- header -->
    <Header :Route="searchRoute" />
  </div>
</template>

<script>
import Header from "../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    searchRoute() {
      return this.$store.getters.routeFilter("Tra cứu");
    },
  },
};
</script>

<style></style>
