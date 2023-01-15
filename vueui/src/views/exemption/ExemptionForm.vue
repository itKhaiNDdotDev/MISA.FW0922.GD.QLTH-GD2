<template>
  <div class="m-popup-wrapper" @keyup.esc="onClose">
    <div class="popup__form exemption-form" id="a">
      <div class="form__header">{{ formTitle }}</div>
      <div class="form__control">
        <button ref='focusMe' tabindex="1" style="margin-left: -16px; opacity: 0; width: 0px"></button>
        <MDropdown :tabIndex="1"
          class="form__input border-radius"
          style="width: 250px"
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
          @click="onFocusOutCell"
        />

        <MInput
          class="form__input border-radius"
          style="width: 110px"
          :label="labelText.DateOfBirth"
          :isDisabled="true"
          :value="formatDate(selectedStudent.studentDateOfBirth)"
          @click="onFocusOutCell"
        />

        <MInput
          class="form__input border-radius"
          style="width: 150px"
          :label="labelText.Class"
          :isDisabled="true"
          :value="selectedStudent.branchName"
          @click="onFocusOutCell"
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
              position: 'fixed',
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
              position: 'fixed',
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
          <thead @click="onFocusOutCell">
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
              <th style="width: 28px; max-width: 28px"></th>
            </tr>
            <div class="thead__no-scroll"></div>
            <div class="thead__border-bot"></div>
          </thead>

          <tbody>
            <tr v-for="(item, index) in exemptionOfStudent" :key="index" :id="item.studentExemptionID + 'Form'">
              <td
                class="cell__text--left"
                style="max-width: 200px"
                :title="item.Fee"
                v-if="!item.isNewRecord"
                @click="isShowCellDropdown=false; isShowCellInput=false;"
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
                :title="item.exemptionName"
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
                @click="isShowCellDropdown=false; isShowCellInput=false;"
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
                @click="isShowCellDropdown=false; isShowCellInput=false;"
                class="cell__text--left"
                style="width: 100px; max-width: 270px"
                itemType="chooseMonth"
              >
                {{ formatDate(item.studentExemptionToDate).slice(-7) }}
              </td>

              <td style="max-width: 24px;"
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
          <div class="table__notice" v-if="isNoResultTable">{{tableNotice}}</div>
        </table>
        
      </div>
      <div class="form__footer" @click="onFocusOutCell">
        <div class="m-button text-button btn-light"
          tabindex="2"
          @click="onClose"
        >
          {{ buttonText.Close }}
        </div>
        <div class="m-button text-button btn-green"
          tabindex="3"
          @click="onSaveData"
          @keydown.tab="onTabEndForm"
        >
          {{ buttonText.Save }}
        </div>
      </div>
      <div
        class="m-icon icon-24 icon-close"
        @click="onClose"
        :title="tooltip.Close"
      ></div>
      <MDialog v-if="isShowDialog"
        @click="onFocusOutCell"
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
import { ResultStatus } from "./../../utils/enums/status";
import { DataAction } from "./../../utils/enums/data-action-flag";
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
      formTitle: this.isInsertMode ? ExemptionResources.Form.Title.Insert : ExemptionResources.Form.Title.Edit,
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
      dialogMsg: "",
      isNoResultTable: false,
      tableNotice: ""
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

    /**
     * Sự kiên khi click vào một table cell trên Form thì hiển thị dropdown/input tương ứng
     * @param {event} event sự kiện khi click vào cell tương ứng
     * @param {Guid} recordID id của bản ghi tương ứng đang tương tác
     * Author: KhaiND (03/01/2022)
     */
    onFocusCell(event, recordID) {
      // lấy ID bản ghi thao tác
      this.selectedRecordID = recordID;
      // Đổi màu focus dòng
      var siblings = event.target.parentElement.parentElement.querySelectorAll("tr");
      if(siblings && siblings.length > 0) {
        for(let i = 0; i < siblings.length; i++) {
          siblings[i].setAttribute("selected", "false");
          console.log(siblings[i]);
        }
      }
      document.getElementById(recordID+"Form").setAttribute("selected", "true");
      //console.log(event.target.parentElement);
      // Hiển thị Dropdown
      //let overTop = document.getElementById("exemptionForm").getBoundingClientRect().top;
      //let overLeft = document.getElementById("exemptionForm").getBoundingClientRect().left;
      this.cellDropdownTop = event.target.getBoundingClientRect().top - 18;// - overTop - 2;
      this.cellDropdownLeft = event.target.getBoundingClientRect().left - 122;// - overLeft - 1;
      this.cellDropdownWidth = event.target.offsetWidth + 1;
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

    /**
     * Khi click ra ngoài các cell có thể focus thì bỏ chọn các dòng và ẩn các deopdown, input của cell
     * Author: KhaiND (09/01/2023)
     */
    onFocusOutCell() {
      this.isShowCellDropdown = false;
      this.isShowCellInput = false;
      var trow = document.querySelectorAll("tr");
      if(trow && trow.length > 0) {
        for(let i = 0; i < trow.length; i++) {
          trow[i].setAttribute("selected", "false");
          console.log(trow[i]);
        }
      }
    },

    /**
     * Xử lý bind kết quả từ dropdown của table cell lên thông tin trên bảng tương ứng trên Form
     * Author: KhaiND (03/01/2022)
     */
    getCellDropdownSelected(item) {
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
                this.$emit("onRequestToast", ResultStatus.WARNING, ExemptionResources.Form.Message.InvalidRangeTime);
              }
            }
            else if(this.cellDropdownLeft > 860 && this.cellDropdownLeft < 960) {
              console.log("TO DATE");
              let foundItem = this.exemptionOfStudent.find(x => x.studentExemptionID === this.selectedRecordID);
              foundItem.studentExemptionToDate = itemDate;
              let fromDate = new Date(foundItem.studentExemptionFromDate);
              let toDate = new Date(foundItem.studentExemptionToDate);
              if(fromDate > toDate) {
                this.$emit("onRequestToast", ResultStatus.WARNING, ExemptionResources.Form.Message.InvalidRangeTime);
              }
            }
          }
        });
      }

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
          temp.flag = DataAction.INSERT;
          //temp.studentExemptionID = null;
        }
        else {
          temp.flag = DataAction.UPDATE;
        }
        this.objectSaveData.push(temp);
      }
      // console.log(this.objectSaveData);
    },

    /**
     * Xủ lý bind dữ liệu khi có thay đổi dữ liệu trên input mức miễn giảm trên table cell của form
     * Author: KhaiND (04/01/2023)
     */
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
          temp.flag = DataAction.INSERT;
          //temp.studentExemptionID = null;
        }
        else {
          temp.flag = DataAction.UPDATE;
        }
        this.objectSaveData.push(temp);
      }
      // console.log(this.objectSaveData);
    },

    /**
     * Gán keyword cho input của Dropdown trên các table cell
     * Author: KhaiND (03/01/2023)
     */
    onChangeCellDropdownKeyword(value) {
      this.cellDropdownValue = value;
    },

    /**
     * Nhận dữ liệu Học sinh được chọn từ Dropdown Học sinh
     * Author: KhaiND (02/01/2023)
     */
    getSelectedStudent(student) {
      this.selectedStudent = student;
      this.onLoadExemptionOfStudent(student.studentID);
      this.studentID = student.studentID;
    },

    /**
     * Thực hiện validate dữ liệu trên Form
     * Author: KhaiND (06/01/2023)
     */
    validateData() {
      //Bỏ các item có fee trống trên DOM
      let foundItem = this.exemptionOfStudent.filter(x => !x.feeID);
      foundItem.forEach(emptyItem => {
        this.exemptionOfStudent.splice(this.exemptionOfStudent.indexOf(emptyItem), 1);
      });

      // Kiểm tra xem đã chọn học sinh hay chưa
      if(!this.studentID) {
        this.dialogMsg = ExemptionResources.Form.Message.RequireStudent;
        this.haveCloseDialog = false;
        this.isShowDialog = true;
        return false;
      }

      var failCount = 0;
      // Kiểm tra trùng thời gian miễn giảm
      var feeIDs = [];
      this.exemptionOfStudent.forEach(keepItem => {
        // Loc ra danh sach feeID
        if(!feeIDs.includes(keepItem.feeID)) {
          feeIDs.push(keepItem.feeID);
        }
      });
      // Duyệt qua từng FeeID và kiểm tra thời gian miễn giảm có bị trùng hay không
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
                  this.dialogMsg = ExemptionResources.Form.Message.preDuplicateExemptionTIme + curFeeItems[i].feeName + ExemptionResources.Form.Message.subDuplicateExemptionTIme;
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
                else if(curToDate >= loopFromDate && curToDate <= loopToDate) {
                  failCount++;
                  // Hiển thị cảnh báo
                  this.dialogMsg = ExemptionResources.Form.Message.preDuplicateExemptionTIme + curFeeItems[i].feeName + ExemptionResources.Form.Message.subDuplicateExemptionTIme;
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
                else if(loopFromDate >= curFromDate && loopFromDate <= curToDate) {
                  failCount++;
                  // Hiển thị cảnh báo
                  this.dialogMsg = ExemptionResources.Form.Message.preDuplicateExemptionTIme + curFeeItems[i].feeName + ExemptionResources.Form.Message.subDuplicateExemptionTIme;
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
                else if(loopToDate >= curFromDate && loopToDate <= curToDate) {
                  failCount++;
                  // Hiển thị cảnh báo
                  this.dialogMsg = ExemptionResources.Form.Message.preDuplicateExemptionTIme + curFeeItems[i].feeName + ExemptionResources.Form.Message.subDuplicateExemptionTIme;
                  this.haveCloseDialog = false;
                  this.isShowDialog = true;
                }
              }
            }
          }
        }
      });

      // Kiểm tra xem có dữ liệu cell nào bắt buộc còn để trống không
      this.objectSaveData.forEach(item => { // ĐIỀU KIỆN IF FLAG !+ 2=======================
        // Không có FromDate, ToDate (Vốn không thể trống rồi - không cần kiểm tra)
        // Kiểm tra FromDate > ToDAte
        let fromDate = new Date(item.studentExemptionFromDate);
        let toDate = new Date(item.studentExemptionToDate);
        if(fromDate > toDate) {
          failCount++;
          let feeName = this.exemptionOfStudent.find(x => x.feeID === item.feeID).feeName;
          this.dialogMsg = ExemptionResources.Form.Message.preInvalidExemptionTime + feeName + ExemptionResources.Form.Message.subInvalidExemptionTime;
          this.haveCloseDialog = false;
          this.isShowDialog = true;
        }

        // Nếu ko có exemption nào dược chọn
        if(!item.exemptionID) {
          // Hiển thị cảnh báo
          this.dialogMsg = ExemptionResources.Form.Message.RequireExemption;
          this.haveCloseDialog = false;
          this.isShowDialog = true;
          // Remove bản ghi khỏi object save
          //this.objectSaveData.splice(this.objectSaveData.indexOf(item), 1);
          failCount++;
        }

        // Ko có Level
         if(!item.studentExemptionLevel) {
          // Hiển thị cảnh báo
          this.dialogMsg = ExemptionResources.Form.Message.RequireLevel;
          this.haveCloseDialog = false;
          this.isShowDialog = true;
          // Remove bản ghi khỏi object save
          //this.objectSaveData.splice(this.objectSaveData.indexOf(item), 1);
          failCount++;
        }

        // Nếu không có fee nào được chọn
        if(!item.feeID) {
          // Hiển thị cảnh báo
          this.dialogMsg = ExemptionResources.Form.Message.RequireFee;
          this.haveCloseDialog = false;
          this.isShowDialog = true;
          // Remove bản ghi khỏi object save
          this.objectSaveData.splice(this.objectSaveData.indexOf(item), 1);
          failCount++;
        }
      });
      console.log(this.objectSaveData);
      // Xử lý kết quả
      if(failCount > 0) {
        return false;
      }
      return true;
    },

    /**
     * Xử lý khi người dùng bấm xác nhận trên Dialog tương ứng
     * Author: KhaiND (03/01/2023)
     */
    onConfirmDialog() {
      if(!this.haveCloseDialog) {
        this.isShowDialog = false;
        if(!this.studentID) {
          this.$refs.student.onFocus();
          // Nên xử lý event input nếu đã có giá trị thì bỏ thông báo lỗi input
        }
      }
    },

    /**
     * Thực hiện gọi APU lưu dữ liệu trên Form hiện tại vào CSDL
     * Author: KhaiND (02/01/2023)
     */
    onSaveData() {
      this.isShowCellDropdown = false;
      this.isShowCellInput = false;
      var me = this;
      if(this.validateData()) {
        this.isLoading = true;
        this.objectSaveData.forEach(item => {
          if(item.flag == DataAction.INSERT) {
            item.studentExemptionID = null;
          }
        });
        axios.post(BASE_URL+"StudentExemptions/save", me.objectSaveData)
          .then((response) => {
            console.log(response);
            this.$emit("onRequestToast", ResultStatus.OK, ExemptionResources.Form.Message.SaveSucess);
            this.$emit("onReload");
            this.onClose();
            this.isLoading = false;
          })
          .catch((response) => {
            console.log(response);
            this.$emit("onRequestToast", ResultStatus.FAIL, ExemptionResources.ToastMessage.ErrorDefault);
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

    /**
     * Load dữ liệu các bản ghi miễn giảm tương ứng học sinh trên Form từ API
     * @param {Guid} studentID ID của hoc sinh tương ứng
     * Author: KhaiND (27/12/2022)
     */
    onLoadExemptionOfStudent(studentID) {
      try {
        var me = this;
        var url = BASE_URL + "StudentExemptions/student/" + studentID;
        axios.get(url).then((response) => {
          me.isNoResultTable = false;
          this.exemptionOfStudent = response.data;
          this.exemptionOfStudent.forEach(item => {
            //Format thời gian miễn giảm
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
        }).catch((response) => {
          if(response.response.status == 404) {
            me.isNoResultTable = true;
            me.tableNotice = ExemptionResources.Form.Message.NoData;
          }
          else {
            me.isNoResultTable = true;
            me.tableNotice = ExemptionResources.ToastMessage.ErrorDefault;
            me.$emit("onRequestToast", ResultStatus.FAIL, ExemptionResources.ToastMessage.ErrorDefault);
          }
        });
      } catch (error) {
        console.log(error);
      }
    },

    /**
     * Load thông tin học sinh được choice từ Dropdown hoặc select từ bảng (lớp, ngày sinh)
     * @param {Guid} studentID ID của hoc sinh tương ứng
     * Author: KhaiND (26/12/2022)
     */
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

    /**
     * Thực hiện xóa dòng dữ liệu tương ứng bảng danh sách miễn giảm của học sinh trên Form
     * @param {event} event sự kiện click vào icon xóa
     * @param {Guid} id ID của bản ghi tương ứng đang xóa
     * Author: KhaiND (27/12/2022)
     */
    onRemoveRow(event, id) { // Bor event du
      //event.target.parentElement.style.display = "none";
      var record = this.exemptionOfStudent.find(x => x.studentExemptionID === id);
      this.exemptionOfStudent.splice(this.exemptionOfStudent.indexOf(record), 1);
    console.log(this.exemptionOfStudent);
      this.isShowCellDropdown = false;
      this.isShowCellInput = false;
      var trow = document.querySelectorAll("tr");
      if(trow && trow.length > 0) {
        for(let i = 0; i < trow.length; i++) {
          trow[i].setAttribute("selected", "false");
          console.log(trow[i]);
        }
      }
      
      var foundItem = this.objectSaveData.find(x => x.studentExemptionID === id);
      if(foundItem) {
        if(foundItem.flag != DataAction.INSERT) {
          foundItem.flag = DataAction.DELETE;
        }
        else {
          this.objectSaveData.splice(this.objectSaveData.indexOf(foundItem), 1);
        }
      }
      else {
        var deleteItem = {};
        deleteItem.studentExemptionID = id;
        deleteItem.flag = DataAction.DELETE;
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

    /**
     * Thực hiện thêm một dòng mới trên bảng danh sách miễn giảm của học sinh trong Form
     * Author: KhaiND (27/12/2022)
     */
    onInsertRow() {
      /**event */
      // let targetTr = event.target.parentElement.parentElement;
      // console.log(targetTr);
      // var newTr = document.createElement("tr");
      // newTr.innerHTML = '<tr> <td><MDropdown class="cell__input"/></td> <td><MDropdown class="cell__input"/></td> <td></td> <td></td><td></td><td></td><td></td></tr>';
      // targetTr.parentElement.insertBefore(newTr, targetTr);
      this.isShowCellDropdown = false;
      this.isShowCellInput = false;
      var trow = document.querySelectorAll("tr");
      if(trow && trow.length > 0) {
        for(let i = 0; i < trow.length; i++) {
          trow[i].setAttribute("selected", "false");
          console.log(trow[i]);
        }
      }
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

    /**
     * Sự kiện khi blur input của dropdown chọn học sinh, nếu chưa chọn thì validate hiển thị thông báo lõi bỏ qua thông tin bắt buộc
     * Author: KhainD (30/12/2022)
     */
    onBlurStudentInput() {
      if(!this.studentID) {
        this.errorStudentInput = {
          isError: true,
          message: ExemptionResources.Form.Message.RequireData
        }
      }
      else {
        this.errorStudentInput = {
          isError: false,
          message: ""
        }
      }
      console.log(this.studentID);
    },

    /**
     * Khi Tab ở cuối Form thì xoay vòng Tab về đầu Form
     * Author: KhaiND (03/01/2022)
     */
    onTabEndForm() {
      this.$nextTick(() => this.$refs.focusMe.focus());
    }
  },

  /**
   * Khi render Form thi load dữ liệu tương ứng
   * Author: KhaiND (27/12/2022)
   */
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
.form__table::-webkit-scrollbar-track {
  margin-top: 32  px;
}
.form__table table thead {
  position: relative;
}
.form__table table thead .thead__no-scroll {
  height: 32px;
  top: 123px;
  right: 17px;
}
.form__table table thead .thead__border-bot {
  top: 154px;
  right: 16px;
  left: 16px;
}

.form__table .table__notice {
  color: #808080;
  padding-top: 10px;
  padding-left: 16px;
}
</style>