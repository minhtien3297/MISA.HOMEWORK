<template>
  <div id="decrease">
    <!-- header -->
    <Header :Route="decreaseRoute" />
  </div>
</template>

<script>
import Header from "../../components/Layout/Header";

export default {
  components: { Header },

  computed: {
    decreaseRoute() {
      return this.$store.getters.submenuFilter("Ghi giảm");
    },
  },
};
</script>

<style>
</style>