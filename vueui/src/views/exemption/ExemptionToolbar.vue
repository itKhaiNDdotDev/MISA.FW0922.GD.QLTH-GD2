<template>
  <div class="content__toolbar">
    <div class="toolbar--left">
      <label for="" style="margin-right: 18px">Xem theo</label>
      <MRadio name="exemptionViewMode" />
      <label class="radio-label" style="margin-right: 8px;" for="">Học sinh</label>
      <MRadio name="exemptionViewMode" />
      <label class="radio-label" for="">Khoản thu</label>
    </div>
    <div class="toolbar--right">
        <div class="m-button text-button btn-green">Thêm</div>
        <div class="m-button text-button btn-green">Thêm nhanh</div>
        <div class="m-button icon-button btn-light m-icon icon-delete-32"></div>
        <div class="m-button icon-button btn-light m-icon icon-print"></div>
        <div class="m-button icon-button btn-light m-icon icon-more"></div>
    </div>
  </div>
</template>

<script>
import MRadio from "./../../components/base/MRadio.vue";

export default {
  name: "ExemptionToolbar",
  components: {
    MRadio,
  },
};
</script>

<style>
  .content__view .toolbar--left {
    display: flex;
    padding: 0px 16px;
  }

  .content__view .toolbar--right {
    display: flex;
    padding: 0px 16px;
  }

  .radio-label {
    margin-left: 4px;
  }
</style>