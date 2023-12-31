# Case Study 1 ทำยังไงให้เร็วขึ้น? <br>
ทำไงให้โปรแกรม Default ทำงานเร็วขึ้นโดยไม่ต้องแก้ไขการบวกลบในฟังก์ชัน sum

## Default 
ผลลัพธ์ในการรัน Default <br>
![image](https://github.com/Jimmymonster/Operating-System/assets/86227832/46ac5030-127e-47cd-927f-338bcdfb6be8)

## Version 1 ทดลองใช้ multithread
ในเวอร์ชั่นนี้จะแก้ไขจาก default เพิ่มเติมมาคือสร้าง thread array ขึ้นมาและให้ thread แบ่งกันรัน function sum โดยไม่ได้มีการแก้ไขในส่วนอื่นเลยนอกจากนี้ ที่ลองใช้ multithread เพราะคิดว่า thread แบ่งกันทำงานแบบ parallel น่าจะทำให้ runtime เร็วขึ้น
### สิ่งที่แก้ไขจาก Version ที่แล้ว
- สร้าง Array ของ Thread ขึ้นมา
- สร้าง Function DividedSum() มาให้แต่ละ Thread ใช้ ซึ่งมีหน้าที่รัน sum(); ตามจำนวนข้อมูลหารจำนวน Thread
<br>

**ผลลัพธ์ที่ได้**
| Number of Threads | Time used(ms)|
| :---------------: | :----------: |
| 1                 | 19807        |
| 2                 | 19718        |
| 4                 | 19681        |
| 8                 | 19717        |
| 16                | 19712        |

คำตอบที่ได้: 888701676 :heavy_check_mark:
<br>
จึงสรุปได้ว่า multithread (อาจจะ) ไม่ได้ส่งผลต่อ run time มากนัก
<br><br>

## Version 2 Seperate Sum
ดัดแปลงต่อจาก Version 1 มีการสร้างตัวแปร array ใหม่ใน global scope ที่เก็บผลบวกของแต่ละ thread แล้วเอามารวมกันอีกทีตอนตอบ เหตุผลที่ลองแยกกันบวก เพราะคิดว่า แทนที่จะบวกกันตัวแปรเดียวตรงกลาง แยกกันบวกแล้วมารวมอีกทีหลังน่าจะเร็วกว่า 
### สิ่งที่แก้ไขจาก Version ที่แล้ว
- เปลี่ยนตัวแปร Sum_Global ให้กลายเป็น array
- แก้ไข Function sum() ให้รับ index ของ Thread ได้
- แก้ไขตัวแปรใน Function sum() ให้สามารถหาผลบวกตาม index ของ Thread ได้
- นำ For loop ไปไว้ใน Function sum()
- นำตัวแปร G_index มาอยู่ใน Function sum() จากเดิมที่เป็นตัวแปร Global 
<br>

**ผลลัพธ์ที่ได้**
| Number of Threads | Time used(ms)|
| :---------------: | :----------: |
| 1                 | 20652        |
| 2                 | 20701        |
| 4                 | 20835        |
| 8                 | 20849        |
| 16                | 20836        |

คำตอบที่ได้: 888701676 :heavy_check_mark:
<br>
จึงสรุปได้ว่าการแยกกันบวก (อาจจะ) ไม่ได้ส่งผลต่อ run time มากนัก
<br><br>

## Version 3 ไม่ใช้ Array
ทดลองเอา array ออกทั้งหมด ไม่ว่าจะเป็น thread กับ sum ของ thread (เนื่องจากไม่มี array จึงต้องเขียนตัวแปรแยกเช่น sum1,sum2 ทำให้ต้องทำฟังก์ชัน sum แยกไปอีกจึงทดลองมาแค่ 2,4 และ 8 thread) ลองเอา array ออกเพราะว่า การเข้าถึงตัวแปรแต่ละช่องใน array ต้องใช้ index และคิดว่าการใช้ index อาจจะส่งผลต่อ runtime เล็กน้อย
### สิ่งที่แก้ไขจาก Version ที่แล้ว
- เปลี่ยนตัวแปร Sum_Global จากเดิมที่เป็น Array กลายเป็น s1,s2,s3,...
- เปลี่ยนตัวแปร Thread ที่เป็น Array กลายเป็น t1,t2,t3,...
- สร้าง Function sum() ใหม่ จากเดิมที่เป็น sum() ตัวเดียว กลายเป็น sum1(),sum2(),sum3(),...
<br>

**ผลลัพธ์ที่ได้**
| Number of Threads | Time used(ms)|
| :---------------: | :----------: |
| 2                 | 10935        |
| 4                 | 9103         |
| 8                 | 5944         |

คำตอบที่ได้: 888701676 :heavy_check_mark:
<br>
จึงสรุปได้ว่าการสร้าง array มีผลกระทบต่อ run time (ที่คิดว่ามีปัญหาจริงๆน่าจะเป็นการสร้าง array ของ thread แต่ array ของ sum ไม่น่าจะมีปัญหามากนัก)
<br><br>

## Version 4 เลิกใช้ Global
ทดลองเอาตัวแปร Global เปลี่ยนเป็น Local เกือบทุกตัวแปร เนื่องจาก function การทำงานต่างๆจะทำอยู่ใน stack memory การเข้าถึงตัวแปร global ใน data segment อาจส่งผลกระะทบต่อ runtime
### สิ่งที่แก้ไขจาก Version ที่แล้ว
- เปลี่ยนตัวแปร s1,s2,s3 เป็น sumAll
- แก้ไข Function sum() ให้มีตัวแปร tmp เอาไว้เก็บผลบวกใน Function
<br>

**ผลลัพธ์ที่ได้**
| Number of Threads | Time used(ms)|
| :---------------: | :----------: |
| 2                 | 9413         |
| 4                 | 5162         |
| 8                 | 3216         |

คำตอบที่ได้: 888701676 :heavy_check_mark:
<br>
จึงสรุปได้ว่าการใช้ตัวแปร local แทน global มีผลการทบต่อ run time
<br><br>

# สรุป
จากการทดลองทั้งหมดจึงสรุปได้ว่า ไม่ควรใช้ array ในงานที่ต้องการความเร็ว และไม่ควรให้ฟังก์ชันเข้าถึงตัวแปร Global บ่อยๆ<br><br>
จริงๆมีไอเดียที่คิดว่าทำแล้วไม่น่าช่วยอะไรอยู่ตามนี้
- บวกผ่าน Recursion -> ไม่ทำเพราะ Stack Overflow แน่ๆ
- ส่งตัวแปร Global เข้าไปใน Function sum -> ถ้า Pass by Value ต้องก๊อปตัวแปร 1000000000 ตัว ถ้า Pass by Reference ก็ไม่ต่างกับการใช้ตัวแปร Global ตรงๆไปเลย
