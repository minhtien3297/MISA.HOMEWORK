<template>
  <div id="category">
    <!-- header -->
    <Header :Route="categoryRoute" />
  </div>
</template>

<script>
import Header from "../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    categoryRoute() {
      return this.$store.getters.routeFilter("Danh mục");
    },
  },
};
</script>

<style></style>
