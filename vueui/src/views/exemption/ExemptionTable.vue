<template>
    <div class="content__table">
        <table>
            <thead>
                <tr>
                    <th><MCheckbox/></th>
                    <th>Họ tên học sinh</th>
                    <th>Ngày sinh</th>
                    <th>Lớp</th>
                    <th>Mức miễn giảm</th>
                    <th>Khoản thu</th>
                    <th>Thời gian miễn giảm</th>
                    <th>Diện miễn giảm</th>
                    <th></th>
                </tr>
            </thead>

            <tbody>
                <tr>
                    <td><MCheckbox/></td>
                    <td>Lương Trung Kiên</td>
                    <td></td>
                    <td>2/2</td>
                    <td>100,00%</td>
                    <td>Sữa học đường</td>
                    <td>Học kỳ I</td>
                    <td>Dân tộc thiểu số</td>
                    <td>
                        <div class="m-icon icon-24 icon-edit"></div>
                        <div class="m-icon icon-24 icon-remove"></div>
                    </td>
                </tr>
                <tr>
                    <td><MCheckbox/></td>
                    <td>Bùi Đức Anh</td>
                    <td></td>
                    <td>3/1</td>
                    <td>50,00%</td>
                    <td>Tiền ăn bán trú</td>
                    <td>Cả năm</td>
                    <td>Con CB, CN, viên chức mà cha hoặc mẹ bị tai nạn lao động hoặc mắc bệnh nghề nghiệp được hưởng trợ cấp TX </td>
                    <td>
                        <div class="m-icon icon-24 icon-edit"></div>
                        <div class="m-icon icon-24 icon-remove"></div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import MCheckbox from "./../../components/base/MCheckbox.vue"

export default {
    name: "ExemptionTable",
    components: {
        MCheckbox
    }
}
</script>

<style>
    
</style>