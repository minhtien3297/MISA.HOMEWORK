<template>
  <div class="pagination">
    <!-- button first page-->
    <a href="#"
      ><svg
        xmlns="http://www.w3.org/2000/svg"
        width="20"
        height="20"
        viewBox="0 0 24 24"
        fill="none"
        stroke="currentColor"
        stroke-width="2"
        stroke-linecap="round"
        stroke-linejoin="round"
        class="feather feather-chevrons-left"
      >
        <polyline points="11 17 6 12 11 7"></polyline>
        <polyline points="18 17 13 12 18 7"></polyline></svg
    ></a>

    <!-- button prev page -->
    <a href="#"
      ><svg
        xmlns="http://www.w3.org/2000/svg"
        width="20"
        height="20"
        viewBox="0 0 24 24"
        fill="none"
        stroke="currentColor"
        stroke-width="2"
        stroke-linecap="round"
        stroke-linejoin="round"
        class="feather feather-chevron-left"
      >
        <polyline points="15 18 9 12 15 6"></polyline></svg
    ></a>

    <a class="page" href="#">1</a>
    <a class="page active" href="#">2</a>
    <a class="page" href="#">3</a>
    <a class="page" href="#">4</a>
    <a class="page" href="#">5</a>
    <a class="page" href="#">6</a>

    <!-- button next page -->
    <a href="#"
      ><svg
        xmlns="http://www.w3.org/2000/svg"
        width="20"
        height="20"
        viewBox="0 0 24 24"
        fill="none"
        stroke="currentColor"
        stroke-width="2"
        stroke-linecap="round"
        stroke-linejoin="round"
        class="feather feather-chevron-right"
      >
        <polyline points="9 18 15 12 9 6"></polyline></svg
    ></a>

    <!-- button last page -->
    <a href="#"
      ><svg
        xmlns="http://www.w3.org/2000/svg"
        width="20"
        height="20"
        viewBox="0 0 24 24"
        fill="none"
        stroke="currentColor"
        stroke-width="2"
        stroke-linecap="round"
        stroke-linejoin="round"
        class="feather feather-chevrons-right"
      >
        <polyline points="13 17 18 12 13 7"></polyline>
        <polyline points="6 17 11 12 6 7"></polyline></svg
    ></a>
  </div>
</template>

<script>
export default {};
</script>

<style>
/* pagination */
.body-right .content .content-footer .pagination{
    display: flex;
    align-items: center;
    margin: auto;
}
    /* pagination page */
    .body-right .content .content-footer .pagination a {
        color: black;
        float: left;
        padding: 8px 14px;
        text-decoration: none;
        margin: 0px 5px;
    }

    /* Hiệu ứng page được chọn */
    .body-right .content .content-footer .pagination .page.active {
        background-color: #019160;
        color: white;
        border-radius: 50%;
    }

    /* Page không được chọn */
    .body-right .content .content-footer .pagination .page:not(active) {
        background-color: #ddd;
        border-radius: 50%;
    }
</style>