<template>
    <div class="content__table">
        <table>
            <thead>
                <tr>
                    <th style="min-width: 40px; max-width: 40px; padding: 0px">
                        <div class="cell__icon"><MCheckbox/></div>
                    </th>
                    <th style="min-width: 150px">
                        Họ tên học sinh
                        <MFilter/>
                    </th>
                    <th style="max-width: 100px">
                        Ngày sinh
                        <MFilter :isInputDate="false"/>
                    </th>
                    <th style="max-width: 60px">
                        Lớp
                        <MFilter/>
                    </th>
                    <th style="max-width: 90px">Mức miễn giảm</th>
                    <th style="max-width: 196px">
                        Khoản thu
                        <MFilter/>
                    </th>
                    <th style="max-width: 100px">Thời gian miễn giảm</th>
                    <th style="max-width: 280px;">
                        Diện miễn giảm
                        <MFilter/>
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
                            <div class="m-icon icon-24 icon-edit"></div>
                            <div class="m-icon icon-24 icon-remove"></div>
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
                            <div class="m-icon icon-24 icon-edit"></div>
                            <div class="m-icon icon-24 icon-remove"></div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import MCheckbox from "./../../components/base/MCheckbox.vue";
import MFilter from "./../../components/base/MFilter.vue";
import axios from "axios";

export default {
    name: "ExemptionTable",
    components: {
        MCheckbox,
        MFilter
    },

    created() {
        axios.post("");
    },
}
</script>

<style scpode>
</style>