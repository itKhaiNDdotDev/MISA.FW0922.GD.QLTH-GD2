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
        <div class="m-button text-button btn-green" @click="onOpenForm">Thêm</div>
        <div class="m-button text-button btn-green">Thêm nhanh</div>
        <div class="m-button icon-button btn-light m-icon icon-delete-32"></div>
        <div class="m-button icon-button btn-light m-icon icon-print"></div>
        <div class="m-button icon-button btn-light m-icon icon-more" @click="toggleMore">
          <div class="toolbar__more" :class="{moreHidden:isHideMore}">
            <div class="more__item m-icon icon-nhapkhau">Nhập khẩu</div>
            <div class="more__item m-icon icon-duplicate">Sao chép danh sách miễn giảm</div>
            <div class="more__item m-icon icon-zoom">Phóng to/thu nhỏ màn hình (F11)</div>
          </div>
        </div>
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

  data() {
    return {
      isHideMore: true
    }
  },

  methods: {
    /**
     * Sự kiện yêu cầu gọi đến Component cha để hiển thị Form
     * Author: KhaiND (13/12/2022)
     */
    onOpenForm() {
      this.$emit("onOpenForm");
    },

    /**
     * Ẩn hiện các lựa chọn nút bấm tính năng mở rộng ở icon more
     * Author: KhaiND (15/12/2022)
     */
    toggleMore() {
      this.isHideMore = !this.isHideMore;
    }
  },
};
</script>

<style>
  .content__view .toolbar--left {
    display: flex;
    padding: 0px 12px;
  }

  .content__view .toolbar--right {
    display: flex;
    padding: 0px 12px;
  }

  .radio-label {
    margin-left: 4px;
  }

  .toolbar--right .icon-more {
    position: relative;
  }

  .toolbar--right .toolbar__more {
    position: absolute;
    top: calc(100% + 2px);
    right: -12px;
    width: 256px;
    background-color: var(--white);
    box-shadow: 4px 0px 10px var(--box-shadow);
    border-radius: 4px;
    z-index: 1;
  }
  .toolbar__more .more__item {
    padding: 8px 16px 8px 36px;
    background-position: 6px center;
    background-size: 24px;
  }
  .toolbar__more .more__item:hover {
    background-color: var(--grid-line-hover);
  }
  .toolbar__more .more__item:focus,
  .toolbar__more .more__item:active {
    background-color: var(--grid-line-focus);
  }

  .moreHidden  {
    display: none;
  }
</style>