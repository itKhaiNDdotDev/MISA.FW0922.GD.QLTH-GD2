<template>
  <div class="m-dropdown m-combobox">
    <button class="m-icon icon-28 icon-down"></button>
    <input type="text" class="m-input"/>
    <table class="dropdown__option combobox__option">
      <thead>
        <tr class="combobox__option--head">
          <th>Họ tên</th>
          <th>Ngày sinh</th>
          <th>Lớp</th>
        </tr>
      </thead>
      <tbody>
        <tr class=".dropdown__option--item">
          <td>Nguyễn Duy Khai</td>
          <td>01/01/2021</td>
          <td>2/2</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
    name: "MCombobox",
};
</script>

<style scoped>
    @import url(../../styles/component/dropdown.css);

    .combobox__option--head {
      text-align: left;
      font-family: OpenSans;
    }
</style>