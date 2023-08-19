# Case Study 1 ทำยังไงให้เร็วขึ้น? <br>
ทำไงให้โปรแกรม Default ทำงานเร็วขึ้นโดยไม่ต้องแก้ไขการบวกลบในฟังก์ชัน sum

## Default 
ผลลัพธ์ในการรัน Default <br>
![image](https://github.com/Jimmymonster/Operating-System/assets/86227832/46ac5030-127e-47cd-927f-338bcdfb6be8)

## Version 1 ทดลองใช้ multithread
ในเวอร์ชั่นนี้จะแก้ไขจาก default เพิ่มเติมมาคือสร้าง thread array ขึ้นมาและให้ thread แบ่งกันรัน function sum โดยไม่ได้มีการแก้ไขในส่วนอื่นเลยนอกจากนี้ <br>
**ผลลัพธ์ที่ได้**
| Number of Threads | Time used(ms)|
| :---------------: | :----------: |
| 1                 | 19807        |
| 2                 | 19718        |
| 4                 | 19681        |
| 8                 | 19717        |
| 16                | 19712        |

จึงสรุปได้ว่า multithread (อาจจะ) ไม่ได้ส่งผลต่อ run time มากนัก
<br><br>

## Version 2 Seperate Sum
ดัดแปลงต่อจาก Version 1 มีการสร้างตัวแปร array ใหม่ใน global scope ที่เก็บผลบวกของแต่ละ thread แล้วเอามารวมกันอีกทีตอนตอบ <br>
**ผลลัพธ์ที่ได้**
| Number of Threads | Time used(ms)|
| :---------------: | :----------: |
| 1                 | 20652        |
| 2                 | 20701        |
| 4                 | 20835        |
| 8                 | 20849        |
| 16                | 20836        |

จึงสรุปได้ว่าการแยกกันบวก (อาจจะ) ไม่ได้ส่งผลต่อ run time มากนัก
<br><br>
