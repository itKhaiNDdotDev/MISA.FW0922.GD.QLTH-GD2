<template>
  <div class="m-dropdown">
    <button class="m-icon icon-28 icon-down"></button>
    <input type="text" class="m-input" value="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" readonly/>
    <div class="dropdown__option">
      <div class="dropdown__option--item">
        Option 1
      </div>
    </div>
  </div>
</template>

<script>
export default {
    name: "MDropdown",
};
</script>

<style scoped>
    @import url(../../styles/component/dropdown.css);
</style>