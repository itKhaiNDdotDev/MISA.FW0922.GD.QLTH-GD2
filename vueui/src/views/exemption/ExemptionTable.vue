<template>
  <div class="content__table">
    <table>
      <thead>
        <tr>
          <th style="min-width: 32px; max-width: 32px;  padding: 0px !important;">
            <div class="cell__icon"><MCheckbox @onCheck="onCheckAll" :isChecked="checkAllRecord"/></div>
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
          <th style="min-width: 128px; max-width: 128px">
            <div class="table__headtext">{{ labelText.DateOfBirth }}</div>
            <MFilter :isInputDate="false" class="table__filter" />
          </th>
          <th style="min-width: 80px; max-width: 80px">
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
        <tr v-for="(item) in studentExemptionList" :key="item.studentExemptionID" @dblclick="onClickEdit(item.studentID)">
          <td style="min-width: 32px; max-width: 32px; padding: 0px !important;">
            <div class="cell__icon"><MCheckbox @onCheck="onSelectRecord(item.studentExemptionID)" :isChecked="checkSelected(item.studentExemptionID)"/></div>
          </td>
          <td class="cell__text--left" style="max-width: 196px" v-if="!isStudentViewMode">
            {{item.feeName}}
          </td>
          <td class="cell__text--left text--link" style="min-width: 150px" @click="onClickEdit(item.studentID)">
            {{item.studentName}}
          </td>
          <td class="cell__text--center" style="max-width: 100px">
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
              <div class="m-icon icon-24 icon-edit" :title="tooltip.Edit" @click="onClickEdit(item.studentID)"></div>
              <div class="m-icon icon-24 icon-remove" :title="tooltip.Delete" @click="onClickDeleteRow(item.studentExemptionID)"></div>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
    <MDialog v-if="isShowDialog" :haveBtnClose="true" :dialogMsg="dialogMsg" @onClose="onCloseDialog" @onConfirm="onDeleteExemption"/>
    <MLoader v-if="isTableLoading"/>
  </div>
</template>

<script>
import Resources from "./../../utils/resources/common";
import ExemptionResources from "./../../utils/resources/exemption";
import MCheckbox from "./../../components/base/MCheckbox.vue";
import MFilter from "./../../components/base/MFilter.vue";
import MDialog from "./../../components/base/MDialog.vue";
import MLoader from "./../../components/base/MLoader.vue";
import axios from "axios";
import { BASE_URL, PAGE_SIZE } from "./../../utils/constants/api";
import { formatDate } from "./../../utils/format-data";

export default {
  name: "ExemptionTable",
  components: {
    MCheckbox,
    MFilter,
    MDialog,
    MLoader
  },

  data() {
    return {
      labelText: ExemptionResources.Label,
      tooltip: Resources.ToolTip,
      confirmMessage: ExemptionResources.ConfirmMessage,
      studentExemptionList: {},
      curPageIndex: 1,
      isStudentViewMode: true,
      isShowDialog: false,
      dialogMsg: "",
      selectedRecordID: null,
      isTableLoading: false,
      selectedIDs: [],
      checkAllRecord: false,
      totalRecord: 0
    };
  },

  created() {
    this.isTableLoading = true;
    this.onLoadStudentExemptionList(true);
  },

  methods: {
    /**
     * Xử lý khi gọi API load dữ liệu danh sách miễn giảm thành công
     * PARAM=========================
     * Author: KhaiND (23/11/2022)
     */
    thenLoadStudentExemptionList(response) {
      this.checkAllRecord = false;
      this.selectedIDs = [];
      this.studentExemptionList = response.data.data;
      this.totalRecord = response.data.totalRecord;
      this.$emit("setTotalRecord", this.totalRecord);
      //this.errorResult = false;
      // Ẩn Loader
      this.isTableLoading = false;
    },

    /**
     * Gọi API lấy (GET) dữ liệu danh sách miễn giảm (phân trang)
     * PARAM=================================
     * Author: KhaiND (23/12/2022)
     */
    onLoadStudentExemptionList(studentViewMode, pageIndex) {
      try {
        this.isStudentViewMode = studentViewMode; // Cần để render bảng
        this.curPageIndex = pageIndex;
        this.curStudentViewMode = studentViewMode;
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
    },

    /**
     * Sự kiện khi click xóa ở bản ghi tương ứng (dòng) trên bảng danh sách miễn giảm thì hiển thị Dialog tương ứng và set ID bản ghi được chọn
     * @param {Guid} id ID của bản ghi muốn xóa
     * Author: KhaiND (28/12/2022)
     */
    onClickDeleteRow(id) {
      this.isShowDialog = true;
      this.dialogMsg = this.confirmMessage.Delete;
      this.selectedRecordID = id;
    },

    /**
     * Sự kiện khi bấm Đóng trên Dialog thì ẩn Dialog tương ứng
     * Author: KhaiND (26/12/2022)
     */
    onCloseDialog() {
      this.isShowDialog = false;
    },

    /**
     * Thực hiện gọi API xóa bản ghi đang được chọn bởi ID tương ứng
     * Author: KhaiND (28/12/2022)
     */
    async onDeleteExemption() {
      try {
        // Hiển thị Loader
        this.isTableLoading = true;
        //Call API
        var url = BASE_URL + "StudentExemptions/" + this.selectedRecordID;
        await axios.delete(url);
        // Reset lại Id và đóng Dialog
        this.isShowDialog = false; // Có thể gọi this.Method
        this.selectedRecordID = null;
        // Ẩn Loader
        this.isTableLoading = false;
        // Reload va toast
        //this.$emit("showToast", this.toastMsg.Employee.DeleteSuccess, ResultStatus.OK);
        // Đặt lại pageIndex nếu dữ liệu trang hiện tại bị xóa hết thì trở về trang trước
        if(this.studentExemptionList.length == 1 && this.curPageIndex > 1) {
          this.curPageIndex -= 1;
        }
        await this.onLoadStudentExemptionList(this.isStudentViewMode, this.curPageIndex);
      }
      catch(error) {
        console.log(error);
        //this.$emit("showToast", this.toastMsg.Error500, ResultStatus.FAIL);
        // Gửi STATE lỗi
      }
    },

    /**
     * Mỗi lần check/uncheck vào chekcbox đầu dàng dữ liệu tương ứng của bảng thì thêm/bỏ Id tương ứng trong danh sách chọn
     * Author: KhaiND (28/12/2022)
     */
    onSelectRecord(id) {
      if (this.selectedIDs.includes(id) && this.selectedIDs != undefined) {
        this.selectedIDs.splice(this.selectedIDs.indexOf(id), 1);
      }
      else {
        this.selectedIDs.push(id);
      }
      // Kiểm tra xem nếu đã check hết các lựa chọn thì tự động tick ô Tất cả
      if (this.selectedIDs.length == this.studentExemptionList.length) {
        this.checkAllRecord = true;
      } else
      {
        this.checkAllRecord = false;
      }
    },

    /**
     * Sự kiện khi bấm vào checkbox ở đầu bảng thì chọn tất cả bản ghi tương ứng đang hiển thị
     * Author: KhaiND (28/12/2022)
     */
    onCheckAll() {
      try {
        this.checkAllRecord = !this.checkAllRecord;
        this.selectedIDs = [];
        if (this.checkAllRecord) {
          for (var i = 0; i < this.studentExemptionList.length; i++) {
            this.selectedIDs.push(this.studentExemptionList[i].studentExemptionID);
          }
        }
      }
      catch(error) {
        console.log(error);
      }
    },

    /**
     * Kiểm tra xem bản ghi tương ứng đã được chọn hay chưa, nếu đã được chọn thì bind động để ô checkbox tương ứng được checked
     * @param {Guid} id ID của bản ghi cần kiểm tra 
     * Author: KhaiND (28/12/2022)
     */
    checkSelected(id) {
      if (this.selectedIDs == undefined) {
        return false;
      }   
      return this.selectedIDs.includes(id);
    },

    /**
     * Chức năng xóa nhiều bản ghi đồng thời
     * Author: KhaiND (28/12/2022)
     */
    async onDeleteManyExemption() {
      try {
        var me = this;
        // Hiển thị Loader
        //this.loadingStatus = true;
        //Call API
        await axios.post(BASE_URL + "StudentExemptions/deleteMany", me.selectedIDs);
        // Đóng Dialog
        //this.isShowDialog = false;
        // Ẩn Loader
        //this.loadingStatus = false;
        // Reload va toast
        //this.$emit("showToast", this.toastMsg.Employee.DeleteManySucessPre + this.empSelectedIds.length + this.toastMsg.Employee.DeleteManySucessSfx, ResultStatus.OK);
        this.selectedIDs = [];
        if(this.checkAllRecord && this.curPageIndex > 1 && this.curPageIndex == Math.ceil(this.totalRecord/PAGE_SIZE)) { // Chỉ trang cuối mới lùi thôi
          this.curPageIndex -= 1;
          this.$emit("setCurPageIndex", this.curPageIndex);
        }
        await this.onLoadStudentExemptionList(this.isStudentViewMode, this.curPageIndex);
      }
      catch(error) {
        console.log(error);
        //this.$emit("showToast", this.toastMsg.Error500, ResultStatus.FAIL);
      }
    },

    /**
     * Sự kiện bấm vào lựa chọn chỉnh sửa thì hiển thị Form chỉnh sửa thông tin
     * @param {Guid} studentID ID của Học sinh tương ứng
     * AUthor: KhaiND (28/12/2022)
     */
    onClickEdit(studentID) {
      this.$emit("onOpenForm", true, studentID);
    },

    /**
     * Trả về cho Component cha danh sách ID đã được chọn (Checked ở checkbox)
     * @returns danh sách ID các bản ghi được chọn
     * Author: KhaiND (28/12/2022)
     */
    getSlectedIDs() {
      return this.selectedIDs;
    }
  },
};
</script>

<style scoped>
table thead {
  z-index: 1;
}

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