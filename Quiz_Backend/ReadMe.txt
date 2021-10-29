
//بعد از تنظیمات ای دنتی تی باید جداول در دیتابیس ایجاد گردد

add-migration inittables -c UserDbContext
update-database -context UserDbContext