<template>
  <div class="content__table">
    <table>
      <thead>
        <tr>
          <th style="min-width: 40px; max-width: 40px; padding: 0px">
            <div class="cell__icon"><MCheckbox /></div>
          </th>
          <th style="max-width: 200px" v-if="!isStudentViewMode">
            <div class="table__headtext">{{ labelText.Fee }}</div>
            <MFilter class="table__filter" />
          </th>
          <th style="min-width: 180px">
            <div class="table__headtext">{{ labelText.Fullname }}</div>
            <MFilter class="table__filter" />
            <!-- <div class="table__filter test">AAAAAAA</div> -->
          </th>
          <th style="min-width: 150px; max-width: 150px">
            <div class="table__headtext">{{ labelText.DateOfBirth }}</div>
            <MFilter :isInputDate="false" class="table__filter" />
          </th>
          <th style="min-width: 100px; max-width: 100px">
            <div class="table__headtext">{{ labelText.Class }}</div>
            <MFilter class="table__filter" />
          </th>
          <th style="min-width: 90px; max-width: 100px">
            {{ labelText.Level }}
          </th>
          <th style="max-width: 200px" v-if="isStudentViewMode">
            <div class="table__headtext">{{ labelText.Fee }}</div>
            <MFilter class="table__filter" />
          </th>
          <th style="min-width: 120px; max-width: 150px">
            {{ labelText.Time }}
          </th>
          <th style="max-width: 280px">
            <div class="table__headtext">{{ labelText.TargetType }}</div>
            <MFilter class="table__filter" />
          </th>
          <th style="width: 64px; min-width: 64px; max-width: 64px; box-sizing: border-box; padding: 0px;"></th>
        </tr>
      </thead>

      <tbody>
        <tr v-for="(item) in studentExemptionList" :key="item.studentExemptionID">
          <td style="min-width: 40px; max-width: 40px; padding: 0px">
            <div class="cell__icon"><MCheckbox /></div>
          </td>
          <td class="cell__text--left" style="max-width: 196px" v-if="!isStudentViewMode">
            {{item.feeName}}
          </td>
          <td class="cell__text--left text--link" style="min-width: 150px">
            {{item.studentName}}
          </td>
          <td class="cell__text--left" style="max-width: 100px">
            {{formatDate(item.studentDateOfBirth)}}
          </td>
          <td class="cell__text--left" style="max-width: 60px">
            {{item.branchName}}
          </td>
          <td class="cell__text--right" style="max-width: 90px">
            {{item.studentExemptionLevel.toFixed(2).replace('.', ',')}}%
          </td>
          <td class="cell__text--left" style="max-width: 196px" v-if="isStudentViewMode">
            {{item.feeName}}
          </td>
          <td class="cell__text--left" style="max-width: 100px">
            {{item.studentExemptionTime}}
          </td>
          <td class="cell__text--left" style="max-width: 280px">
            {{item.exemptionName}}
          </td>
          <td style="width: 64px; min-width: 64px; max-width: 64px; box-sizing: border-box; padding: 0px;">
            <div class="cell__icon">
              <div class="m-icon icon-24 icon-edit" :title="tooltip.Edit"></div>
              <div class="m-icon icon-24 icon-remove" :title="tooltip.Delete"></div>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import Resources from "./../../utils/resources/common";
import ExemptionResources from "./../../utils/resources/exemption";
import MCheckbox from "./../../components/base/MCheckbox.vue";
import MFilter from "./../../components/base/MFilter.vue";
import axios from "axios";
import { BASE_URL, PAGE_SIZE } from "./../../utils/constants/api";
import { formatDate } from "./../../utils/format-data"

export default {
  name: "ExemptionTable",
  components: {
    MCheckbox,
    MFilter,
  },

  data() {
    return {
      labelText: ExemptionResources.Label,
      tooltip: Resources.ToolTip,
      studentExemptionList: {},
      //curPageIndex: 1,
      isStudentViewMode: true
    };
  },

  created() {
    this.onLoadStudentExemptionList(true);
  },

  methods: {
    /**
     * Xử lý khi gọi API load dữ liệu danh sách miễn giảm thành công
     * PARAM=========================
     * Author: KhaiND (23/11/2022)
     */
    thenLoadStudentExemptionList(response) {
      //this.checkAllEmplyee = false;
      //this.empSelectedIds = [];
      this.studentExemptionList = response.data.data;
      this.$emit("setTotalRecord", response.data.totalRecord);
      //this.errorResult = false;
      //// Ẩn Loader
      //this.tableLoadingStatus = false;
      console.log(response);
    },

    /**
     * Gọi API lấy (GET) dữ liệu danh sách miễn giảm (phân trang)
     * PARAM=================================
     * Author: KhaiND (23/12/2022)
     */
    onLoadStudentExemptionList(studentViewMode, pageIndex) {
      try {
        this.isStudentViewMode = studentViewMode; // Cần để render bảng
        //this.curPageIndex = pageIndex; // Tạm thời giữ xem delete trong bảng có cần không
        // this.$emit("setPageIndex", this.curPageIndex); // Tạm thời giữ xem delete trong bảng có cần không
        // this.tableLoadingStatus = true;
        if (!pageIndex) {
          pageIndex = 1;
        }
        if(studentViewMode) {
          var url = BASE_URL + "StudentExemptions/paging/student?pageIndex=" + pageIndex + "&pageSize=" + PAGE_SIZE;
        }
        else {
          url = BASE_URL + "StudentExemptions/paging/fee?pageIndex=" + pageIndex + "&pageSize=" + PAGE_SIZE;
        }
        axios.get(url).then((response) => this.thenLoadStudentExemptionList(response))
          .catch((response) => {
            console.log(response);
        });
      } catch (error) {
        // this.employeeList = null;
        // this.$emit("showToast", this.errorResultText.Error500, ResultStatus.FAIL);
        console.log(error);
      }
    },

    /**
     * Gọi hàm định dạng ngày thành DD/MM/YYYY
     * @param {String} value - chuỗi giá trị thời gian cần định dạng
     * @returns chuỗi giá trị ngày đã định dạng
     * Author: KhaiND (26/12/2022)
     */
    formatDate(value) {
      return formatDate(value);
    }
  },
};
</script>

<style scoped>
table th {
  position: relative;
  height: 64px;
}

table th .table__headtext {
  position: absolute;
  top: 0px;
  left: 0px;
  right: 0px;
  height: 32px;
  padding: inherit;
  box-sizing: border-box;
}

table th .table__filter {
  position: absolute;
  top: 28px;
  left: 10px;
  right: 10px;
}
</style>