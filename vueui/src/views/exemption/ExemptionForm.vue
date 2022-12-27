<template>
    <div class="m-popup-wrapper">
        <div class="popup__form exemption-form">
            <div class="form__header">{{formTitle}}</div>
            <div class="form__control">
                <MDropdown class="form__input border-radius" style="width: 220px;" :label="labelText.Student" :isRequired="true"
                    optionEnpoint="Students" :optionHeader="optionHeaderStudent" @getSelected="getSelectedStudent"
                />
                <MInput class="form__input border-radius" style="width: 110px;" :label="labelText.DateOfBirth" :isDisabled="true"
                    :value="formatDate(selectedStudent.studentDateOfBirth)"
                />
                <MInput class="form__input border-radius" style="width: 150px;" :label="labelText.Class" :isDisabled="true"
                    :value="selectedStudent.branchName"
                />
            </div>
            <div class="form__table">
                <table>
                    <thead>
                        <tr>
                            <th style="min-width: 160px; max-width: 200px;">{{labelText.Fee}}</th>
                            <th style="max-width: 270px;">{{labelText.TargetType}}</th>
                            <th style="width: 130px; max-width: 130px;">{{labelText.Level}}</th>
                            <th style="width: 150px; max-width: 150px;">{{labelText.Time}}</th>
                            <th style="width: 100px; max-width: 100px;">{{labelText.FromMonth}}</th>
                            <th style="width: 100px; max-width: 100px;">{{labelText.ToMonth}}</th>
                            <th style="width: 36px; max-width: 40px;"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="(item, index) in exemptionOfStudent" :key="index">
                            <td class="cell__text--left" style="max-width: 200px;" :title="item.Fee">{{item.Fee}}</td>

                            <td class="cell__text--left" style="max-width: 270px;" :title="item.TargetType"
                                @click="onFocusCell" @blur="onBlurInputCell"
                            >
                                {{item.TargetType}}
                                <MDropdown class="cell__input" :optionHeader="optionExemptionHeader" :propData="optionExemptionData"/>                
                            </td>
                            <!-- <MDropdown class="cell__input" :numberColumn="3"/> -->

                            <td class="cell__text--right" style="width: 130px; max-width: 130px;"
                                @click="onFocusCell" @blur="onBlurInputCell"
                            >
                                {{item.Level.toFixed(2).replace('.', ',')}}%
                                <MInput class="cell__input"/>
                            </td>
                            <!-- <MInput class="cell__input"/> -->

                            <td style="width: 150px; max-width: 150px;" :title="item.Time" @click="onFocusCell"
                                @blur="onBlurInputCell"
                            >
                                {{item.Time}}
                                <MDropdown class="cell__input" :numberColumn="3"/>
                            </td>
                            <!-- <MDropdown class="cell__input" :numberColumn="3"/> -->

                            <td class="cell__text--left" style="width: 100px; max-width: 270px;" @click="onFocusCell"
                                @blur="onBlurInputCell"
                            >
                                {{item.FromMonth}}
                                <MDropdown class="cell__input"/>
                            </td>
                            <!-- <MDropdown class="cell__input"/> -->

                            <td class="cell__text--left" style="width: 100px; max-width: 270px;" @click="onFocusCell"
                                @blur="onBlurInputCell"
                            >
                                {{item.ToMonth}}
                                <MDropdown class="cell__input"/>
                            </td>
                            <!-- <MDropdown class="cell__input"/> -->

                            <td class="m-icon icon-24 icon-remove" :title="tooltip.Delete"></td>
                        </tr>
                        <tr class="table__tr--add">
                            <td colspan="7">
                                <div class="m-icon icon-plus-blue text--link">{{labelText.Insert}}</div>
                            </td>          
                        </tr>
                    </tbody>
                </table>

            </div>
            <div class="form__footer">
                <div class="m-button text-button btn-light" @click="onClose">{{buttonText.Close}}</div>
                <div class="m-button text-button btn-green">{{buttonText.Save}}</div>
            </div>
            <div class="m-icon icon-24 icon-close" @click="onClose" :title="tooltip.Close"></div>
        </div>
    </div>
</template>

<script>
import Resources from "./../../utils/resources/common";
import ExemptionResources from "./../../utils/resources/exemption";
import MInput from "./../../components/base/MInput.vue";
import MDropdown from "./../../components/base/MDropdown.vue";
import { formatDate } from "./../../utils/format-data";

export default {
    name: "ExemptionForm",
    components: {
        MInput,
        MDropdown
    },

    data() {
        return {
            isShow: true,
            formTitle: ExemptionResources.Form.Title.Insert,
            labelText: ExemptionResources.Label,
            buttonText: Resources.Button,
            tooltip: Resources.ToolTip,
            errorInputSate: {
                isError: true,
                message: "Có lỗi rồi"
            },
            exemptionOfStudent: [
                {
                    Fee: "Sữa học đường",
                    TargetType: "Con hạ sỹ quan, binh sĩ, chiến sĩ",
                    Level: 100,
                    Time: "Cả năm",
                    FromMonth: "08/2021",
                    ToMonth: "05/2022"
                },
                {
                    Fee: "Tiền ăn bán trú",
                    TargetType: "Bị tàn tật, khuyết tật thuộc diện hộ nghèo hoặc hộ cận nghèo",
                    Level: 50,
                    Time: "Học kỳ I",
                    FromMonth: "08/2021",
                    ToMonth: "01/2022"
                }
            ],
            //STUDENT
            optionHeaderStudent: [
                {
                propTitle: "Họ và tên",
                propName: "studentName"
                },
                {
                propTitle: "Ngày sinh",
                propName: "studentDateOfBirth",
                propType: Date
                },
                {
                propTitle: "Lớp",
                propName: "branchName"
                }
            ],
            selectedStudent: {},
            optionExemptionData: [
                {itemName: "Option 1"},
                {itemName: "Option 1"},
                {itemName: "Option 1"},
                {itemName: "Option 1"}
            ],
            optionExemptionHeader: [
                { propTitle:"Test", propName: "itemName" }
            ]
        }
    },

    methods: {
        /**
         * Sự kiên khi bấm vào yêu cầu đóng thì gọi đến Component cha để yêu cầu hủy DOM của Form
         * Author: KhaiND (13/12/2022)
         */
        onClose() {
            try {
                this.$emit("onClose");
            }
            catch(error) {
                console.log(error);
                // Gửi STATE báo lỗi về cha
            }
        },

        onFocusCell(event) {
            if(event.target.querySelector(".cell__input")) {
                // event.target.style.display = "none";
                event.target.querySelector(".cell__input").style.display = "block";
                event.target.querySelector('input').focus();
            }   
        },

        // onBlurInputCell(event) { // BLUR này cần dùng emit gọi vào input chứ đel phải td
        //     console.log(event.target);
        //     event.target.parentElement.parentElement.style.display = "none";
        //     event.target.parentElement.parentElement.previousSibling.style.display = "table-cell";
        //     // event.target.parentElement.querySelector('input').focus();
        // }

        getSelectedStudent(student) {
            this.selectedStudent = student;
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
}
</script>

<style>
    .popup__form {
        width: 1024px;
        height: 512px;
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
    }
    .form__table table {
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
        z-index: 10;
    }

    .form__table td {
        overflow: unset; /********CAANF XEM XAT LAI CAN THAN */
    }
</style>