<template>
  <div class="content__toolbar">
    <div class="toolbar--left">
      <label for="" style="margin-right: 18px">{{labelText.ViewMode}}</label>
      <MRadio name="exemptionViewMode" :isChecked="true" :value="radioValue.Student" @changeViewMode="setTableStudentViewMode"/>
      <label class="radio-label" style="margin-right: 8px;" for="">{{labelText.Student}}</label>
      <MRadio name="exemptionViewMode" :value="radioValue.Fee" ref="radioViewMode" @changeViewMode="setTableStudentViewMode"/>
      <label class="radio-label" for="">{{labelText.Fee}}</label>
    </div>
    <div class="toolbar--right">
        <div class="m-button text-button btn-green" @click="onOpenForm">{{buttonText.Add}}</div>
        <div class="m-button text-button btn-green">{{buttonText.QuickAdd}}</div>
        <div class="m-button icon-button btn-light m-icon icon-delete-32" :title="tooltip.Delete"></div>
        <div class="m-button icon-button btn-light m-icon icon-print" :title="tooltip.Print"></div>
        <div class="m-button icon-button btn-light" @click="toggleMore">
          <div class="m-icon icon-32 icon-more" :title="tooltip.More"></div>
          <div class="toolbar__more" :class="{moreHidden:isHideMore}">
            <div class="more__item m-icon icon-nhapkhau">{{buttonText.Import}}</div>
            <div class="more__item m-icon icon-duplicate">{{buttonText.Coppy + " " + labelText.List.toLowerCase()}}</div>
            <div class="more__item m-icon icon-zoom">{{buttonText.Zoom}}</div>
          </div>
        </div>
    </div>
  </div>
</template>

<script>
import Resources from "./../../utils/resources/common";
import ExemptionResources from "./../../utils/resources/exemption"
import MRadio from "./../../components/base/MRadio.vue";

export default {
  name: "ExemptionToolbar",
  components: {
    MRadio,
  },

  data() {
    return {
      buttonText: Resources.Button,
      tooltip: Resources.ToolTip,
      labelText: ExemptionResources.Label,
      radioValue: ExemptionResources.RadioValue.TableViewMode,
      isHideMore: true,
      tableStudentViewMode: true
    }
  },

  methods: {
    /**
     * Sự kiện yêu cầu gọi đến Component cha để hiển thị Form
     * Author: KhaiND (13/12/2022)
     */
    onOpenForm() {
      try {
        this.$emit("onOpenForm");
      }
      catch(error) {
        console.log(error);
        // Gửi Sate báo lỗi về component cha
      }
    },

    /**
     * Ẩn hiện các lựa chọn nút bấm tính năng mở rộng ở icon more
     * Author: KhaiND (15/12/2022)
     */
    toggleMore() {
      try {
        this.isHideMore = !this.isHideMore;
      }
      catch(error) {
        console.log(error);
        // Gửi Sate báo lỗi về component cha
      }
    },

    /**
     * Set giá trị cho data tableStudentViewMode - mode xem dữ liệu ở bảng là xem theo Học sinh hay không (xem theo Khoản thu)?
     * @param {value} String - Nhận giá trị value của radio input được chọn tương ứng - Giá trị: "student" (xem theo Học sinh), "fee" (xem theo Khoản thu)
     * Author: KhaiND (23/12/2022)
     */
    setTableStudentViewMode(value) {
      try {
        if(value == this.radioValue.Student) {
          this.tableStudentViewMode = true;
        }
        else {
          this.tableStudentViewMode = false;
        }
        // console.log("STUDENT MODE: " + this.tableStudentViewMode);
      }
      catch(error) {
        console.log(error);
        // Gửi Sate báo lỗi về component cha
      }
    }
  },

  watch: {
    /**
   * Theo dõi khi giá trị của tableStudentMode thay đổi thì gọi yêu cầu Component cha load lại dữ liệu theo API tương ứng
   * @param {Boolean} value - Mode xem dữ liệu phân trang của bảng có phải xem theo Học sinh hay không? - Giá trị: true (xem theo Học sinh), false (xem theo Khoản thu)
   * Author: KhaiND (23/12/2022)
   */
    tableStudentViewMode(value) {
      try {
        this.$emit("loadTableData", value);
      }
      catch(error) {
        console.log(error);
        // Gửi Sate báo lỗi về component cha
      }
    }
  }
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

  .content__view .toolbar--left label {
    display: flex;
    align-items: center;
  }

  .radio-label {
    margin-left: 4px;
  }

  .toolbar--right .m-button {
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