<template>
  <div class="m-popup-wrapper" @keyup.esc="onClose">
    <div class="popup__form exemption-form" id="a">
      <div class="form__header">{{ formTitle }}</div>
      <div class="form__control">
        <MDropdown
          class="form__input border-radius"
          style="width: 220px"
          :label="labelText.Student"
          :isRequired="true"
          :isDisabled="!isInsertMode"
          ref="student"
          optionEnpoint="Students"
          :optionHeader="optionHeaderStudent"
          @getSelected="getSelectedStudent"
          :isAutoFocus="true"
          :isError="errorStudentInput.isError"
          :errorMsg="errorStudentInput.message"
          @onBlur="onBlurStudentInput"
        />

        <MInput
          class="form__input border-radius"
          style="width: 110px"
          :label="labelText.DateOfBirth"
          :isDisabled="true"
          :value="formatDate(selectedStudent.studentDateOfBirth)"
        />

        <MInput
          class="form__input border-radius"
          style="width: 150px"
          :label="labelText.Class"
          :isDisabled="true"
          :value="selectedStudent.branchName"
        />
      </div>

      <div class="form__table" id="exemptionForm">
        <div ref="cellDropdown">
          <MDropdown
            v-if="isShowCellDropdown"
            :optionHeader="optionHeaderDropdown"
            :optionEnpoint="optionEndpointDropdown"
            :propData="fixDataDeopdown"
            :style="{
              position: 'absolute',
              top: cellDropdownTop + 'px',
              left: cellDropdownLeft + 'px',
              width: cellDropdownWidth + 'px',
              zIndex: '5',
            }"
            :isAutoFocus="true"
            :value="cellDropdownValue"
            @onFocusOut="onFocusOutCellInput"
            @getSelected="getCellDropdownSelected"
            @getKeyword="onChangeCellDropdownKeyword"
          />
          <MInput v-if="isShowCellInput"
            type="number"
            :style="{
              position: 'absolute',
              top: cellDropdownTop + 'px',
              left: cellDropdownLeft + 'px',
              width: cellDropdownWidth + 'px',
              zIndex: '5',
            }"
            :isAutoFocus="true"
            :value="cellDropdownValue"
            @onChangeInput="onChangeCellInput"
          />
        </div>
        <table>
          <thead>
            <tr>
              <th style="min-width: 160px; max-width: 200px">
                {{ labelText.Fee }}
              </th>
              <th style="min-width: 270px; max-width: 270px">
                {{ labelText.TargetType }}
              </th>
              <th style="width: 130px; max-width: 130px">
                {{ labelText.Level }}
              </th>
              <th style="width: 150px; max-width: 150px">
                {{ labelText.Time }}
              </th>
              <th style="width: 100px; max-width: 100px">
                {{ labelText.FromMonth }}
              </th>
              <th style="width: 100px; max-width: 100px">
                {{ labelText.ToMonth }}
              </th>
              <th style="width: 36px; max-width: 40px"></th>
            </tr>
          </thead>

          <tbody>
            <tr v-for="(item, index) in exemptionOfStudent" :key="index">
              <td
                class="cell__text--left"
                style="max-width: 200px"
                :title="item.Fee"
                v-if="!item.isNewRecord"
              >
                {{ item.feeName }}
              </td>
              <td
                class="cell__text--left"
                style="max-width: 200px"
                :title="item.Fee"
                v-else
                @click="onFocusCell($event, item.studentExemptionID)"
                itemType="feeName"
              >
                {{ item.feeName }}
              </td>

              <td
                class="cell__text--left"
                style="max-width: 270px"
                :title="item.TargetType"
                @click="onFocusCell($event, item.studentExemptionID)"
                itemType="exemptionName"
              >
                {{ item.exemptionName }}
              </td>

              <td
                class="cell__text--right"
                style="width: 130px; max-width: 130px"
                @click="onFocusCell($event, item.studentExemptionID)"
                v-if="item.studentExemptionLevel"
                itemType="exemptionLevel"
              >
                {{ item.studentExemptionLevel.toFixed(2).replace(".", ",") }}%
              </td>
              <td
                class="cell__text--right"
                style="width: 130px; max-width: 130px"
                v-else
                @click="onFocusCell($event, item.studentExemptionID)"
                itemType="exemptionLevel"
              >%</td>

              <td
                style="width: 150px; max-width: 150px"
                :title="item.Time"
                @click="onFocusCell($event, item.studentExemptionID)"
                itemType="exemptionTime"
              >
                {{ item.studentExemptionTime }}
              </td>

              <td v-if="item.studentExemptionTime == exemptionTimeData[3]"
                class="cell__text--left"
                style="width: 100px; max-width: 270px"
                @click="onFocusCell($event, item.studentExemptionID)"
                itemType="chooseMonth"
              >
                {{ formatDate(item.studentExemptionFromDate).slice(-7) }}
              </td>
              <td v-else
                class="cell__text--left"
                style="width: 100px; max-width: 270px"
                itemType="chooseMonth"
              >
                {{ formatDate(item.studentExemptionFromDate).slice(-7) }}
              </td>

              <td v-if="item.studentExemptionTime == exemptionTimeData[3]"
                class="cell__text--left"
                style="width: 100px; max-width: 270px"
                @click="onFocusCell($event, item.studentExemptionID)"
                itemType="chooseMonth"
              >
                {{ formatDate(item.studentExemptionToDate).slice(-7) }}
              </td>
              <td v-else
                class="cell__text--left"
                style="width: 100px; max-width: 270px"
                itemType="chooseMonth"
              >
                {{ formatDate(item.studentExemptionToDate).slice(-7) }}
              </td>

              <td
                class="m-icon icon-24 icon-remove"
                :title="tooltip.Delete"
                @click="onRemoveRow($event, item.studentExemptionID)"
              ></td>
            </tr>
            <tr class="table__tr--add" @click="onInsertRow">
              <td colspan="7">
                <div class="m-icon icon-plus-blue text--link">
                  {{ labelText.Insert }}
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="form__footer">
        <div class="m-button text-button btn-light" @click="onClose">
          {{ buttonText.Close }}
        </div>
        <div class="m-button text-button btn-green" @click="onSaveData">{{ buttonText.Save }}</div>
      </div>
      <div
        class="m-icon icon-24 icon-close"
        @click="onClose"
        :title="tooltip.Close"
      ></div>
      <MDialog v-if="isShowDialog"
      :haveBtnClose="haveCloseDialog"
      :dialogMsg="dialogMsg"
      @onClose="isShowDialog=false"
      @onConfirm="onConfirmDialog"
    />
    </div>
    <MLoader v-if="isLoading"/>
    
  </div>
</template>

<script>
import Resources from "./../../utils/resources/common";
import ExemptionResources from "./../../utils/resources/exemption";
import MInput from "./../../components/base/MInput.vue";
import MDropdown from "./../../components/base/MDropdown.vue";
import MLoader from "./../../components/base/MLoader.vue";
import MDialog from "./../../components/base/MDialog.vue";
import { formatDate } from "./../../utils/format-data";
import { BASE_URL } from "@/utils/constants/api";
import axios from "axios";
import ClickOutside from "vue-click-outside";

export default {
  name: "ExemptionForm",
  components: {
    MInput,
    MDropdown,
    MLoader,
    MDialog
  },

  data() {
    return {
      formTitle: this.isInsertMode
        ? ExemptionResources.Form.Title.Insert
        : ExemptionResources.Form.Title.Edit,
      labelText: ExemptionResources.Label,
      buttonText: Resources.Button,
      tooltip: Resources.ToolTip,
      studentID: this.selectedStudentID, ///
      exemptionOfStudent: [],
      //STUDENT
      optionHeaderStudent: [
        {
          propTitle: "Họ và tên",
          propName: "studentName",
        },
        {
          propTitle: "Ngày sinh",
          propName: "studentDateOfBirth",
          propType: Date,
        },
        {
          propTitle: "Lớp",
          propName: "branchName",
        },
      ],
      selectedStudent: {},
      //CELL DROPDOWN
      optionHeaderDropdown: [],
      optionEndpointDropdown: "",
      fixDataDeopdown: null,
      //EXEMPTION
      optionHeaderExemption: [
        {
          propTitle: "Diện miễn giảm",
          propName: "exemptionName",
        },
        {
          propTitle: "Mức miễn giảm",
          propName: "exemptionFixLevel",
        },
      ],
      //FEE
      optionHeaderFee: [
        {
          propTitle: "Khoản thu",
          propName: "feeName",
        }
      ],
      //EXEMPTION TIME
      exemptionTimeData: [
        "Cả năm",
        "Học kỳ I",
        "Học kỳ II",
        "Tùy chọn"
      ],
      chooseMonthData: [
        "2021-01-02T01:01:01",
        "2021-02-02T01:01:01",
        "2021-03-02T01:01:01",
        "2021-04-02T01:01:01",
        "2021-05-02T01:01:01",
        "2021-06-02T01:01:01",
        "2021-07-02T01:01:01",
        "2021-08-02T01:01:01",
        "2021-09-02T01:01:01",
        "2021-10-02T01:01:01",
        "2021-11-02T01:01:01",
        "2021-12-02T01:01:01",
        "2022-01-02T01:01:01",
        "2022-02-02T01:01:01",
        "2022-03-02T01:01:01",
        "2022-04-02T01:01:01",
        "2022-05-02T01:01:01",
        "2022-06-02T01:01:01",
        "2022-07-02T01:01:01",
        "2022-08-02T01:01:01",
        "2022-09-02T01:01:01",
        "2022-10-02T01:01:01", 
        "2022-11-02T01:01:01",
        "2022-12-02T01:01:01"
      ],
      isShowCellDropdown: false,
      isShowCellInput: false,
      cellDropdownTop: 0,
      cellDropdownLeft: 0,
      cellDropdownWidth: 0,
      cellDropdownValue: "",
      selectedRecordID: null,
      objectSaveData: [],
      baseID: 1,
      isLoading: false,
      errorStudentInput: {},
      isShowDialog: false,
      haveCloseDialog: false,
      dialogMsg: ""
    };
  },
  props: ["selectedStudentID", "isInsertMode"],

  methods: {
    /**
     * Sự kiên khi bấm vào yêu cầu đóng thì gọi đến Component cha để yêu cầu hủy DOM của Form
     * Author: KhaiND (13/12/2022)
     */
    onClose() {
      try {
        this.$emit("onClose");
      } catch (error) {
        console.log(error);
        // Gửi STATE báo lỗi về cha
      }
    },

    onFocusCell(event, recordID) {
      // lấy ID bản ghi thao tác
      this.selectedRecordID = recordID;
      console.log(this.selectedRecordID);

      // Hiển thị Dropdown
      let overTop = document.getElementById("exemptionForm").getBoundingClientRect().top;
      let overLeft = document.getElementById("exemptionForm").getBoundingClientRect().left;
      this.cellDropdownTop = event.target.getBoundingClientRect().top - overTop - 2;
      this.cellDropdownLeft = event.target.getBoundingClientRect().left - overLeft - 1;
      this.cellDropdownWidth = event.target.offsetWidth;
      if(event.target.textContent) {
        this.cellDropdownValue = event.target.textContent;
      }
      else {
        this.cellDropdownValue = "";
      }

      let type = event.target.getAttribute("itemType");
      if(type == "exemptionLevel") {
        this.cellDropdownValue = parseFloat(this.cellDropdownValue);
        this.isShowCellDropdown = false;
        this.isShowCellInput = true;
      }
      else {
        if(type == "feeName") {
          this.fixDataDeopdown = null;
          this.optionHeaderDropdown = this.optionHeaderFee;
          this.optionEndpointDropdown = "Fees";
        }
        else if(type == "exemptionName") {
          this.fixDataDeopdown = null;
          this.optionHeaderDropdown = this.optionHeaderExemption;
          this.optionEndpointDropdown = "Exemptions";
        }
        else if(type == "exemptionTime") {
          this.fixDataDeopdown = this.exemptionTimeData;
        }
        else if(type == "chooseMonth") {
          let mounthData = [];
          this.chooseMonthData.forEach(item => {
            mounthData.push(formatDate(item).slice(-7));
          });
          this.fixDataDeopdown = mounthData;
        }
        this.isShowCellDropdown = true;
        this.isShowCellInput = false;
      }
    },

    getCellDropdownSelected(item) { // Bind thành công dữ liệu 3/1, tìm cách custom lại input
      if(item.exemptionID) {
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).exemptionID = item.exemptionID;
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).exemptionName = item.exemptionName;
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionLevel = item.exemptionFixLevel;
        // Đã bind được ra object mà chưa render được lên cell
      }
      else if(item.feeID) {
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).feeID = item.feeID;
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).feeName = item.feeName;
      }
      else if(item == "Cả năm") {
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionTime = item;
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionFromDate = this.chooseMonthData[7];
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionToDate = this.chooseMonthData[16];
      }
      else if(item == "Học kỳ I") {
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionTime = item;
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionFromDate = this.chooseMonthData[7];
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionToDate = this.chooseMonthData[11];
      }
      else if(item == "Học kỳ II") {
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionTime = item;
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionFromDate = this.chooseMonthData[12];
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionToDate = this.chooseMonthData[16];
      }
      else if(item == "Tùy chọn") {
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionTime = item;
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionFromDate = this.chooseMonthData[7];
        this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID).studentExemptionToDate = this.chooseMonthData[16];
      }
      else {
        // Chọn tháng thì bind Date
        this.chooseMonthData.forEach(itemDate => {
          let month = formatDate(itemDate).slice(-7);
          if(item == month) {
            console.log(itemDate);
            // Đã lấy được ngày choice, làm sao để biết là from hay to
            console.log(this.cellDropdownLeft);
            if(this.cellDropdownLeft > 750 && this.cellDropdownLeft < 850) {
              console.log("FROM DATE");
              let foundItem = this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID);
              foundItem.studentExemptionFromDate = itemDate;
              let fromDate = new Date(foundItem.studentExemptionFromDate);
              let toDate = new Date(foundItem.studentExemptionToDate);
              if(fromDate > toDate) {
                this.$emit("onRequestToast", 2, "Từ tháng đến tháng không đúng");
              }
            }
            else if(this.cellDropdownLeft > 860 && this.cellDropdownLeft < 960) {
              console.log("TO DATE");
              let foundItem = this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID);
              foundItem.studentExemptionToDate = itemDate;
              let fromDate = new Date(foundItem.studentExemptionFromDate);
              let toDate = new Date(foundItem.studentExemptionToDate);
              if(fromDate > toDate) {
                this.$emit("onRequestToast", 2, "Từ tháng đến tháng không đúng");
              }
            }
          }
        });
      }
      // Chọn Date thì bind ngược lại tùy chọn

      // Kiểm tra ngày bé hơn formDate

      console.log(this.exemptionOfStudent);
      // Tiếp tục xử lý thời gian (tháng formated và datetime tương ứng) và input level
      // Nghĩ cách bind base nhiều dropdown khác nhau (tính đến fixed data trước r tính đến insert feeID)
      
      //Buid object du lieu
      var foundItem = this.objectSaveData.find(item => item.studentExemptionID == this.selectedRecordID);
      if(foundItem) {
        // Neu da co trong object danh sach thi sua thong tin tuong ung
        let dataItem = this.exemptionOfStudent.find(x => x.studentExemptionID == this.selectedRecordID);
        foundItem.feeID = dataItem.feeID;
        foundItem.exemptionID = dataItem.exemptionID;
        foundItem.studentExemptionLevel = dataItem.studentExemptionLevel;
        //foundItem.studentExemptionLevelIsUnitByPercent = dataItem.studentExemptionLevelIsUnitByPercent;
        foundItem.studentExemptionFromDate = dataItem.studentExemptionFromDate;
        foundItem.studentExemptionToDate = dataItem.studentExemptionToDate;
      }
      else {
        // Neu co action thi push vao object danh sach
        var temp = {};
        let dataItem = this.exemptionOfStudent.find(x => x.studentExemptionID == this.selectedRecordID);
        temp.studentID = this.studentID;
        temp.feeID = dataItem.feeID;
        temp.exemptionID = dataItem.exemptionID;
        temp.studentExemptionLevel = dataItem.studentExemptionLevel;
        temp.studentExemptionLevelIsUnitByPercent = dataItem.studentExemptionLevelIsUnitByPercent;
        temp.studentExemptionFromDate = dataItem.studentExemptionFromDate;
        temp.studentExemptionToDate = dataItem.studentExemptionToDate;
        temp.studentExemptionID = dataItem.studentExemptionID;
        if(dataItem.isNewRecord) {
          temp.flag = 0;
          //temp.studentExemptionID = null;
        }
        else {
          temp.flag = 1;
        }
        this.objectSaveData.push(temp);
      }
      console.log(this.objectSaveData);
    },

    onChangeCellInput(value) {
      // this.studentExemptionLevel = value;
      // Validate % bang cach kiem tra value thi thuc hien ko thi thoi
      this.exemptionOfStudent.find(x => x.studentExemptionID == this.selectedRecordID).studentExemptionLevel = parseFloat(value);
      this.cellDropdownValue = parseFloat(value);
      // Build object du lieu
      var foundItem = this.objectSaveData.find(item => item.studentExemptionID == this.selectedRecordID);
      if(foundItem) {
        let dataItem = this.exemptionOfStudent.find(x => x.studentExemptionID == this.selectedRecordID);
        foundItem.studentExemptionLevel = dataItem.studentExemptionLevel;
        foundItem.studentExemptionLevelIsUnitByPercent = dataItem.studentExemptionLevelIsUnitByPercent;
      }
      else {
        var temp = {};
        let dataItem = this.exemptionOfStudent.find(x => x.studentExemptionID == this.selectedRecordID);
        temp.studentExemptionID = dataItem.studentExemptionID;
        temp.studentID = this.studentID;
        temp.feeID = dataItem.feeID;
        temp.exemptionID = dataItem.exemptionID;
        temp.studentExemptionLevel = dataItem.studentExemptionLevel;
        temp.studentExemptionLevelIsUnitByPercent = dataItem.studentExemptionLevelIsUnitByPercent;
        temp.studentExemptionFromDate = dataItem.studentExemptionFromDate;
        temp.studentExemptionToDate = dataItem.studentExemptionToDate;
        if(dataItem.isNewRecord) {
          temp.flag = 0;
          //temp.studentExemptionID = null;
        }
        else {
          temp.flag = 1;
        }
        this.objectSaveData.push(temp);
      }
      console.log(this.objectSaveData);
    },

    onChangeCellDropdownKeyword(value) {
      this.cellDropdownValue = value;
    },

    getSelectedStudent(student) {
      this.selectedStudent = student;
      this.onLoadExemptionOfStudent(student.studentID);
      this.studentID = student.studentID;
    },

    validateData() {
      //Bỏ các item có fee trống trên DOM
      let foundItem = this.exemptionOfStudent.filter(x => !x.feeID);
      foundItem.forEach(emptyItem => {
        this.exemptionOfStudent.splice(this.exemptionOfStudent.indexOf(emptyItem), 1);
      });

      // Kiểm tra xem đã chọn học sinh hay chưa
      if(!this.studentID) {
        this.dialogMsg = "Bạn chưa chọn Học sinh nào! Vui lòng kiểm tra lại.";
        this.haveCloseDialog = false;
        this.isShowDialog = true;
        return false;
      }

      // Kiểm tra xem có dữ liệu cell nào bắt buộc còn để trống không
      var failCount = 0;
      this.objectSaveData.forEach(item => {
        // Nếu ko có exemption nào dược chọn
        if(!item.exemptionID) {
          // Hiển thị cảnh báo
          this.dialogMsg = "Thông tin Diện miễn giảm không được để trống. Vui lòng kiểm tra lại.";
          this.haveCloseDialog = false;
          this.isShowDialog = true;
          // Remove bản ghi khỏi object save
          //this.objectSaveData.splice(this.objectSaveData.indexOf(item), 1);
          failCount++;
        }

        // Ko có Level
         if(!item.studentExemptionLevel) {
          // Hiển thị cảnh báo
          this.dialogMsg = "Thông tin Mức miễn giảm không được để trống. Vui lòng kiểm tra lại.";
          this.haveCloseDialog = false;
          this.isShowDialog = true;
          // Remove bản ghi khỏi object save
          //this.objectSaveData.splice(this.objectSaveData.indexOf(item), 1);
          failCount++;
        }

        // Không có FromDate, ToDate (Vốn không thể trống rồi - không cần kiểm tra)
        // Kiểm tra FromDate > ToDAte
        let fromDate = new Date(item.studentExemptionFromDate);
        let toDate = new Date(item.studentExemptionToDate);
        if(fromDate > toDate) {
          failCount++;
          let feeName = this.exemptionOfStudent.find(x => x.feeID === item.feeID).feeName;
          this.dialogMsg = "Thời gian Từ tháng - Đến tháng của khoản thu " + feeName + " không đúng. Vui lòng kiểm tra lại.";
          this.haveCloseDialog = false;
          this.isShowDialog = true;
        }

        // Nếu không có fee nào được chọn
        if(!item.feeID) {
          // Hiển thị cảnh báo
          this.dialogMsg = "Bạn chưa chọn Khoản thu cho danh sách miễn giảm! Vui lòng kiểm tra lại.";
          this.haveCloseDialog = false;
          this.isShowDialog = true;
          // Remove bản ghi khỏi object save
          this.objectSaveData.splice(this.objectSaveData.indexOf(item), 1);
          failCount++;
        }
      });

      // Kiểm tra trùng thời gian miễn giảm
      var feeIDs = [];
      this.exemptionOfStudent.forEach(keepItem => {
        // Loc ra danh sach feeID
        if(!feeIDs.includes(keepItem.feeID)) {
          feeIDs.push(keepItem.feeID);
        }
      });

      feeIDs.forEach(itemFeeID => {
        var curFeeItems = this.exemptionOfStudent.filter(x => x.feeID == itemFeeID);
        if(curFeeItems) {
          if(curFeeItems.length > 1) {
            for(let i = 0;  i < curFeeItems.length - 1; i++) {
              let curFromDate = new Date(curFeeItems[i].studentExemptionFromDate);
              let curToDate = new Date(curFeeItems[i].studentExemptionToDate);
              for(let j = i + 1; j < curFeeItems.length; j++) {
                let loopFromDate = new Date(curFeeItems[j].studentExemptionFromDate);
                let loopToDate = new Date(curFeeItems[j].studentExemptionToDate);
                if(curFromDate >= loopFromDate && curFromDate <= loopToDate) {
                  failCount++;
                  // Hiển thị cảnh báo
                  this.dialogMsg = "Khoản thu " + curFeeItems[i].feeName + " đang bị trùng thời gian miễn giảm! Vui lòng kiểm tra lại.";
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
                if(curToDate >= loopFromDate && curToDate <= loopToDate) {
                  failCount++;
                  // Hiển thị cảnh báo
                  this.dialogMsg = "Khoản thu " + curFeeItems[i].feeName + " đang bị trùng thời gian miễn giảm! Vui lòng kiểm tra lại.";
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
                if(loopFromDate >= curFromDate && loopFromDate <= curToDate) {
                  failCount++;
                  // Hiển thị cảnh báo
                  this.dialogMsg = "Khoản thu " + curFeeItems[i].feeName + " đang bị trùng thời gian miễn giảm! Vui lòng kiểm tra lại.";
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
                if(loopToDate >= curFromDate && loopToDate <= curToDate) {
                  failCount++;
                  // Hiển thị cảnh báo
                  this.dialogMsg = "Khoản thu " + curFeeItems[i].feeName + " đang bị trùng thời gian miễn giảm! Vui lòng kiểm tra lại.";
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
              }
            }
          }
        }
      });
      
      if(failCount > 0) {
        return false;
      }
      return true;
    },

    onConfirmDialog() {
      if(!this.haveCloseDialog) {
        this.isShowDialog = false;
        if(!this.studentID) {
          this.$refs.student.onFocus();
          // Nên xử lý event input nếu đã có giá trị thì bỏ thông báo lỗi input
        }
      }
    },

    onSaveData() {
      this.isShowCellDropdown = false;
      this.isShowCellInput = false;
      var me = this;
      if(this.validateData()) {
        this.isLoading = true;
        this.objectSaveData.forEach(item => {
          if(item.flag == 0) {
            item.studentExemptionID = null;
          }
        });
        axios.post(BASE_URL+"StudentExemptions/save", me.objectSaveData)
          .then((response) => {
            console.log(response);
            this.$emit("onRequestToast", 1, "Luu thanhf coong");
            this.$emit("onReload");
            this.onClose();
            this.isLoading = false;
          })
          .catch((response) => {
            console.log(response);
            this.$emit("onRequestToast", 0, "Cos looix xay ra!!!");
            this.isLoading = false;
          });
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

    onLoadExemptionOfStudent(studentID) {
      try {
        var url = BASE_URL + "StudentExemptions/student/" + studentID;
        axios.get(url).then((response) => {
          this.exemptionOfStudent = response.data;
          this.exemptionOfStudent.forEach(item => {
            let fromDate = new Date(item.studentExemptionFromDate);
            let toDate = new Date(item.studentExemptionToDate);
            let fromM = fromDate.getMonth() + 1;
            let toM = toDate.getMonth() + 1;
            let formY = fromDate.getFullYear();
            let toY = toDate.getFullYear();
            item.studentExemptionTime = fromM + "///" + formY + " --- " + toM + "///" + toY;
            if(fromM == 8 && formY == 2021 && toM == 5 && toY == 2022) {
              item.studentExemptionTime = "Cả năm";
            }
            else if(fromM == 8 && formY == 2021 && toM == 12 && toY == 2021) {
              item.studentExemptionTime = "Học kỳ I";
            }
            else if(fromM == 1 && formY == 2022 && toM == 5 && toY == 2022) {
              item.studentExemptionTime = "Học Kỳ II";
            }
            else {
              item.studentExemptionTime = "Tùy chọn";
            }
          });
        });
      } catch (error) {
        console.log(error);
      }
    },

    onLoadStudent(studentID) {
      try {
        var url = BASE_URL + "Students/" + studentID;
        axios.get(url).then((response) => {
          this.selectedStudent = response.data;
          this.$refs.student.setKeyword(this.selectedStudent.studentName);
        });
      } catch (error) {
        console.log(error);
      }
    },

    onRemoveRow(event, id) { // Bor event du
      //event.target.parentElement.style.display = "none";
      var record = this.exemptionOfStudent.find(x => x.studentExemptionID === id);
      this.exemptionOfStudent.splice(this.exemptionOfStudent.indexOf(record), 1);
      this.isShowCellDropdown = false;
      this.isShowCellInput = false;
      
      var foundItem = this.objectSaveData.find(x => x.studentExemptionID === id);
      if(foundItem) {
        if(foundItem.flag != 0) {
          foundItem.flag = 2;
        }
        else {
          this.objectSaveData.splice(this.objectSaveData.indexOf(foundItem), 1);
        }
      }
      else {
        var deleteItem = {};
        deleteItem.studentExemptionID = id;
        deleteItem.flag = 2;
        deleteItem.feeID = 0;
        deleteItem.exemptionID = 0;
        deleteItem.studentExemptionLevel = 1;
        deleteItem.studentExemptionLevelIsUnitByPercent = 1;
        deleteItem.studentExemptionFromDate = this.chooseMonthData[1];
        deleteItem.studentExemptionToDate = this.chooseMonthData[1];
        this.objectSaveData.push(deleteItem);
      }
      // Đánh flag xóa vào object
      console.log(this.objectSaveData);
    },

    onInsertRow() {
      /**event */
      // let targetTr = event.target.parentElement.parentElement;
      // console.log(targetTr);
      // var newTr = document.createElement("tr");
      // newTr.innerHTML = '<tr> <td><MDropdown class="cell__input"/></td> <td><MDropdown class="cell__input"/></td> <td></td> <td></td><td></td><td></td><td></td></tr>';
      // targetTr.parentElement.insertBefore(newTr, targetTr);
      this.baseID = this.baseID + 1;
      this.exemptionOfStudent.push({
        studentExemptionID: this.baseID,
        studentID: this.studentID,
        studentExemptionLevelIsUnitByPercent: 1,
        studentExemptionTime: this.exemptionTimeData[0],
        studentExemptionFromDate: this.chooseMonthData[7],
        studentExemptionToDate: this.chooseMonthData[16],
        isNewRecord: 1
      });
    },

    onBlurStudentInput() {
      if(!this.studentID) {
        this.errorStudentInput = {
          isError: true,
          message: "Dữ liệu không được phép để trông"
        }
      }
      else {
        this.errorStudentInput = {
          isError: false,
          message: ""
        }
      }
      console.log(this.studentID);
    }
  },

  created() {
    this.onLoadExemptionOfStudent(this.selectedStudentID);
    // Lấy thông tin Student
    this.onLoadStudent(this.selectedStudentID);
    this.baseID = 1;

    // window.addEventListener("click", (event) => {
    //   if (!this.$el.contains(event.target)) {
    //     //this.isShowCellDropdown = false;
    //   }
    // });
  },

  // do not forget this section
  directives: {
    ClickOutside,
  },
};
</script>

<style>
.exemption-form {
  width: 1124px;
  height: 600px; /**Cần fix lai min */
  display: flex;
  flex-direction: column;
  z-index: 3;
}

.form__header {
  font-size: 16px;
  font-family: OpenSansSemiBold;
  padding: 16px;
}

.form__control {
  padding: 0px 16px;
  height: 64px;
  width: fit-content;
  display: flex;
}
.form__control .form__input {
  margin-right: 16px;
}

.form__table {
  flex: 1;
  border: 1px solid var(--border);
  margin: 4px 16px;
  position: relative;
  overflow: scroll;
}
.form__table > table {
  position: absolute;
  top: -1px;
  left: -1px;
  width: calc(100% + 2px);
}
.form__table .table__tr--add {
  border-top: 2px solid var(--border);
}
.form__table .table__tr--add td div {
  background-position: 0px center;
  padding-left: 20px;
}

.form__footer {
  height: 56px;
  display: flex;
  align-items: center;
  justify-content: right;
  padding-right: 16px;
}

.popup__form .icon-close {
  position: absolute;
  top: 8px;
  right: 8px;
}

.form__table table thead {
  z-index: 1;
}

.form__table tbody tr td {
  position: relative;
}

.form__table .cell__input {
  display: none;
  position: absolute;
  top: -1px;
  left: -1px;
  right: -1px;
  height: -1px;
}

.form__table td {
  overflow: hidden; /********CAANF XEM XAT LAI CAN THAN */
}
</style>