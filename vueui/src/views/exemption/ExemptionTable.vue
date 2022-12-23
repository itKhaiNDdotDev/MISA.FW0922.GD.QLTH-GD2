<template>
    <div class="content__table">
        <table>
            <thead>
                <tr>
                    <th style="min-width: 40px; max-width: 40px; padding: 0px">
                        <div class="cell__icon"><MCheckbox/></div>
                    </th>
                    <th style="min-width: 180px">
                        <div class="table__headtext">{{labelText.Fullname}}</div>
                        <MFilter class="table__filter"/>
                        <!-- <div class="table__filter test">AAAAAAA</div> -->
                    </th>
                    <th style="min-width: 150px; max-width: 150px;">
                        <div class="table__headtext">{{labelText.DateOfBirth}}</div>
                        <MFilter :isInputDate="false" class="table__filter"/>
                    </th>
                    <th style="min-width: 100px; max-width: 100px;">
                        <div class="table__headtext">{{labelText.Class}}</div>
                        <MFilter class="table__filter"/>
                    </th>
                    <th style="min-width: 90px; max-width: 100px;">{{labelText.Level}}</th>
                    <th style="max-width: 200px;">
                        <div class="table__headtext">{{labelText.Fee}}</div>
                        <MFilter class="table__filter"/>
                    </th>
                    <th style="min-width: 120px; max-width: 150px">{{labelText.Time}}</th>
                    <th style="max-width: 280px;">
                        <div class="table__headtext">{{labelText.TargetType}}</div>
                        <MFilter class="table__filter"/>
                    </th>
                    <th style="width: 64px; min-width: 64px; max-width: 64px; box-sizing: border-box; padding: 0px;"></th>
                </tr>
            </thead>

            <tbody>
                <tr>
                    <td style="min-width: 40px; max-width: 40px; padding: 0px">
                        <div class="cell__icon"><MCheckbox/></div>
                    </td>
                    <td class="cell__text--left text--link" style="min-width: 150px">Lương Trung Kiên</td>
                    <td class="cell__text--left" style="max-width: 100px"></td>
                    <td class="cell__text--left" style="max-width: 60px">2/2</td>
                    <td class="cell__text--right" style="max-width: 90px">100,00%</td>
                    <td class="cell__text--left" style="max-width: 196px">Sữa học đường</td>
                    <td class="cell__text--left" style="max-width: 100px">Học kỳ I</td>
                    <td class="cell__text--left" style="max-width: 280px;">Dân tộc thiểu số</td>
                    <td style="width: 64px; min-width: 64px; max-width: 64px; box-sizing: border-box; padding: 0px;">
                        <div class="cell__icon">
                            <div class="m-icon icon-24 icon-edit" :title="tooltip.Edit"></div>
                            <div class="m-icon icon-24 icon-remove" :title="tooltip.Delete"></div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="min-width: 40px; max-width: 40px; padding: 0px">
                        <div class="cell__icon"><MCheckbox/></div>
                    </td>
                    <td class="cell__text--left text--link" style="min-width: 150px">Bùi Đức Anh</td>
                    <td class="cell__text--left" style="max-width: 100px">14/11/2014</td>
                    <td class="cell__text--left" style="max-width: 60px">12/12</td>
                    <td class="cell__text--right" style="max-width: 90px">50,00%</td>
                    <td class="cell__text--left" style="max-width: 196px">Tiền ăn bán trú</td>
                    <td class="cell__text--left" style="max-width: 100px">Cả năm</td>
                    <td class="cell__text--left" style="max-width: 280px;">Con CB, CN, viên chức mà cha hoặc mẹ bị tai nạn lao động hoặc mắc bệnh nghề nghiệp được hưởng trợ cấp TX </td>
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

export default {
    name: "ExemptionTable",
    components: {
        MCheckbox,
        MFilter
    },

    data() {
        return {
            labelText: ExemptionResources.Label,
            tooltip: Resources.ToolTip
        }
    },

    created() {
        axios.post("");
    },
}
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