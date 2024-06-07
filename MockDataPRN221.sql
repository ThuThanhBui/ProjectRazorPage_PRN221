--role
insert into Role (id, roleName) values ('b83f20ac-3a21-4a5f-835d-cf745c4505e5', 'Admin');
insert into Role (id, roleName) values ('d07887c4-22ca-4e13-b0ae-ca1fc97cf017', 'Staff');
insert into Role (id, roleName) values ('13cdcaa1-614f-431e-bc5b-d7bfcb483ec7', 'Member');

--[User]
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('ab7677b6-f3e1-4b3d-81d8-956f65fd85d8', 'Maire Slee', 'admin@gmail.com', 'admin123@', '627-496-1679', '1/21/2007', 'Female', 'PO Box 4145', 1, '11/1/2023', '9/30/2023', 'b83f20ac-3a21-4a5f-835d-cf745c4505e5');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('5768be85-7e6e-4811-8065-18b2d2521bff', 'Vlad Spriggen', 'staff@gamil.com', 'staff123@', '610-460-7620', '7/17/1989', 'Genderqueer', 'Apt 1855', 1, '9/26/2023', '3/13/2024', 'd07887c4-22ca-4e13-b0ae-ca1fc97cf017');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId)
values ('a8e689b5-a1ab-4f2b-aabc-6b181e9d1a7d', 'Bobine Rushton', 'brushton2@t-online.de', 'sH7|k&kWe', '838-698-0355', '2/15/2008', 'Female', '9th Floor', 1, '11/6/2023', '12/25/2023', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId)
values ('840937fd-178d-4170-a9f9-e1f4fa89f816', 'Bordy O''Scanlan', 'boscanlan3@umich.edu', 'rG5>"Xu9i#so', '713-429-3670', '6/25/2004', 'Male', 'PO Box 90749', 1, '3/17/2024', '11/2/2023', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('97e33e6b-4120-4e54-8243-6644b6707b6f', 'Jed Coldicott', 'jcoldicott4@youku.com', 'lY2''>}MhuGfi', '400-886-7326', '7/20/1987', 'Male', 'PO Box 26759', 1, '4/11/2024', '2/29/2024', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('8c79b700-2903-4878-8bcd-ca965cad668f', 'Quintus Harlin', 'qharlin5@ebay.com', 'kE7$`}GU+39fII<', '626-340-4604', '8/16/1999', 'Male', '1st Floor', 1, '12/17/2023', '2/27/2024', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('1b6e76a9-cac0-47da-8e41-64f8646531ba', 'Morna Pummell', 'mpummell6@xing.com', 'kV4)1"oD!o8Ynl', '801-995-9258', '4/20/2007', 'Female', '5th Floor', 1, '8/6/2023', '2/9/2024', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');

--blog la staff dang
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('efda74a1-09b0-440f-b28f-d4d06feafdf8', 'Cách Chọn Sữa Công Thức Phù Hợp Cho Bé Yêu', 'Việc chọn sữa công thức phù hợp cho bé yêu có thể là một thách thức đối với nhiều bậc phụ huynh. Bài viết này sẽ cung cấp một hướng dẫn chi tiết về các tiêu chí cần xem xét khi chọn sữa công thức, bao gồm thành phần dinh dưỡng, độ tuổi của bé, các nhu cầu đặc biệt như dị ứng hay không dung nạp lactose, và các thương hiệu uy tín trên thị trường. Bạn sẽ được trang bị đầy đủ thông tin để đưa ra quyết định đúng đắn cho sự phát triển khỏe mạnh của con mình.', 1, '1/25/2024', '8/3/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('bd550819-ed10-41d4-bbb6-e9954776cec2', 'Chăm Sóc Dinh Dưỡng Cho Mẹ Bầu: Những Điều Cần Biết', 'Dinh dưỡng trong thời kỳ mang thai đóng vai trò quan trọng trong việc đảm bảo sức khỏe của cả mẹ và thai nhi. Bài viết này sẽ cung cấp thông tin chi tiết về những dưỡng chất thiết yếu mẹ bầu cần bổ sung, bao gồm axit folic, sắt, canxi, và các loại vitamin khác. Đồng thời, bài viết cũng sẽ đưa ra những gợi ý về thực đơn hàng ngày và các loại thực phẩm nên tránh để đảm bảo một thai kỳ khỏe mạnh và an toàn.', 1, '9/13/2023', '10/5/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('d6250801-7518-4588-8278-895242b875d8', 'Bí Quyết Giúp Bé Yêu Tiêu Hóa Tốt Hơn', 'Hệ tiêu hóa của trẻ nhỏ rất nhạy cảm và cần được chăm sóc đặc biệt. Trong bài viết này, chúng tôi sẽ chia sẻ những bí quyết giúp cải thiện hệ tiêu hóa của bé, từ việc chọn loại sữa phù hợp, cách pha sữa đúng cách, đến việc xây dựng các thói quen ăn uống lành mạnh. Bạn sẽ tìm thấy những mẹo hữu ích giúp bé yêu tiêu hóa tốt hơn và phát triển khỏe mạnh.', 1, '10/27/2023', '12/29/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('3cb91017-0215-45d9-aa2a-ced2b3f21838', 'Sữa Công Thức Hữu Cơ: Lựa Chọn An Toàn Cho Bé Yêu', 'Sữa công thức hữu cơ ngày càng trở nên phổ biến và được nhiều cha mẹ tin dùng. Bài viết sẽ giải thích về lợi ích của sữa công thức hữu cơ, như không chứa chất bảo quản, không có hormone tăng trưởng, và được sản xuất từ các nguồn nguyên liệu an toàn, không biến đổi gen. Đồng thời, chúng tôi sẽ giới thiệu một số thương hiệu sữa công thức hữu cơ uy tín để bạn có thêm sự lựa chọn cho bé yêu của mình.', 1, '7/3/2023', '3/28/2024', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('79f7cf52-f46c-48aa-9b5e-db980ab4461b', 'Các Dấu Hiệu Bé Cần Thay Đổi Loại Sữa Công Thức', 'Việc nhận biết các dấu hiệu cho thấy bé không phù hợp với loại sữa công thức hiện tại là rất quan trọng để đảm bảo sức khỏe cho bé. Bài viết sẽ giúp bạn nhận biết những dấu hiệu như dị ứng, rối loạn tiêu hóa, hoặc không tăng cân đúng chuẩn. Chúng tôi cũng sẽ cung cấp hướng dẫn cách thay đổi loại sữa sao cho an toàn và hiệu quả, đảm bảo bé yêu nhận được dinh dưỡng tốt nhất.', 1, '3/2/2024', '6/9/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('343ccc40-9dfc-4b12-8807-e8bb3ea71f06', 'Những Sai Lầm Thường Gặp Khi Pha Sữa Công Thức', 'Pha sữa công thức cho bé yêu tưởng chừng như đơn giản nhưng lại có thể gặp nhiều sai lầm nếu không cẩn thận. Bài viết này sẽ liệt kê những lỗi phổ biến mà các bậc phụ huynh thường mắc phải khi pha sữa công thức, chẳng hạn như không đúng tỉ lệ nước và bột sữa, sử dụng nước quá nóng hoặc quá lạnh, và không vệ sinh dụng cụ pha sữa đúng cách. Chúng tôi cũng sẽ đưa ra những giải pháp để khắc phục những lỗi này, đảm bảo bé yêu được hưởng trọn vẹn dinh dưỡng từ sữa.', 1, '3/11/2024', '10/2/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');

--product  type
insert into [ProductType] (id, productType) values ('a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f', 'Sữa Cho Bé');
insert into [ProductType] (id, productType) values ('336d6005-a320-498a-8a1d-cc42f07a15d9', 'Sữa Cho Mẹ Bầu');
insert into [ProductType] (id, productType) values ('281d84e6-3c79-4d9c-bbfa-53df3692c486', 'Thực Phẩm Dinh Dưỡng Cho Bé');

--product
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId)
values ('f04f091b-f47d-41f3-98d6-a0932cad13ed', 'Sữa Công Thức Cho Trẻ Sơ Sinh (0-6 tháng)', 'Sữa công thức cho trẻ sơ sinh cung cấp đầy đủ dưỡng chất thiết yếu như đạm whey dễ tiêu hóa, DHA, ARA, và các vitamin, khoáng chất quan trọng giúp hỗ trợ phát triển não bộ, thị giác và hệ miễn dịch cho bé.', 10, 100, 1, '9/7/2023', '10/6/2023', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('ba7325bd-0f1d-4f5c-a260-d3221e8bceb1', 'Sữa Công Thức Cho Trẻ Từ 6-12 Tháng', 'Sữa công thức cho trẻ từ 6-12 tháng bổ sung thêm đạm, sắt, canxi và vitamin nhóm B để hỗ trợ tăng trưởng, phát triển xương và hệ thần kinh, đồng thời tăng cường hệ tiêu hóa và miễn dịch với probiotics.', 20, 200, 1, '8/8/2023', '10/8/2023', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('0c0f9f3d-1448-40ee-b058-9dd1b6eabfcc', 'Sữa Công Thức Cho Trẻ Trên 1 Tuổi', 'Sữa công thức cho trẻ trên 1 tuổi cung cấp canxi, vitamin D, DHA và các dưỡng chất cần thiết giúp phát triển xương, răng và não bộ, đồng thời bổ sung năng lượng và hỗ trợ hệ tiêu hóa khỏe mạnh.', 14, 300, 1, '8/21/2023', '7/28/2023', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659e6', 'Sữa Công Thức Đặc Biệt (Dành cho trẻ dị ứng, không dung nạp lactose, sữa hữu cơ)', 'Sữa công thức đặc biệt dành cho trẻ có nhu cầu đặc biệt như dị ứng đạm sữa bò, không dung nạp lactose, hoặc muốn sử dụng sữa hữu cơ. Sản phẩm cung cấp đầy đủ dưỡng chất, đảm bảo an toàn và phù hợp với sức khỏe của bé.', 4, 4, 1, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('dc91709f-f1b3-4d0b-9b96-fd7eded0ca31', 'Sữa Bầu Bổ Sung Dinh Dưỡng', 'Sữa bầu cung cấp đầy đủ dưỡng chất thiết yếu như protein, vitamin, khoáng chất giúp mẹ bầu duy trì sức khỏe và hỗ trợ sự phát triển toàn diện của thai nhi.', 15, 150, 1, '11/16/2023', '11/5/2023', '336d6005-a320-498a-8a1d-cc42f07a15d9');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('b4339254-6294-49bc-a571-7ca630e64bd8', 'Sữa Bầu Giàu Canxi', 'Sữa bầu giàu canxi giúp mẹ bầu tăng cường sức khỏe xương và răng, đồng thời hỗ trợ sự phát triển hệ xương của thai nhi, ngăn ngừa loãng xương sau sinh.', 23, 250, 1, '5/8/2024', '11/30/2023', '336d6005-a320-498a-8a1d-cc42f07a15d9');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('c2366bd4-33b1-4a96-aed2-af4011397ae6', 'Sữa Bầu Giàu DHA', 'Sữa bầu giàu DHA hỗ trợ phát triển não bộ và thị giác của thai nhi, đồng thời giúp cải thiện trí nhớ và giảm stress cho mẹ bầu trong suốt thai kỳ.', 8, 300, 1, '8/7/2023', '9/2/2023', '336d6005-a320-498a-8a1d-cc42f07a15d9');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('809f2ca2-d1e2-4824-85a7-4ac83039e45f', 'Bột Ăn Dặm Cho Trẻ 4-6 Tháng', 'Bột ăn dặm cho trẻ 4-6 tháng có thành phần dinh dưỡng cân đối, dễ tiêu hóa, giúp bổ sung dưỡng chất cần thiết cho sự phát triển và tăng cường hệ miễn dịch cho bé.', 16, 180, 1, '2/16/2024', '7/6/2023', '281d84e6-3c79-4d9c-bbfa-53df3692c486');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('248125dc-92f9-42bb-9238-3e5794022d84', 'Bột Ăn Dặm Cho Trẻ 6-12 Tháng', 'Bột ăn dặm cho trẻ 6-12 tháng được bổ sung thêm vitamin và khoáng chất, giúp bé phát triển toàn diện về thể chất và trí não trong giai đoạn ăn dặm.', 12, 220, 1, '7/28/2023', '11/12/2023', '281d84e6-3c79-4d9c-bbfa-53df3692c486');
insert into product (id, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('79c63cb3-772e-4b59-b9e5-ccbb2bc30bdf', 'Bột Ăn Dặm Hữu Cơ', 'Bột ăn dặm hữu cơ được làm từ nguyên liệu tự nhiên, không chứa hóa chất và chất bảo quản, đảm bảo an toàn và cung cấp đầy đủ dinh dưỡng cho bé.', 10, 190, 1, '10/27/2023', '10/23/2023', '281d84e6-3c79-4d9c-bbfa-53df3692c486');

--product feedback
insert into ProductFeedback (id, rating, comment, isDeleted, createdDate, updatedDate, userId, productId) values ('0c9d521c-5ce9-4bc3-b9e5-ea4224523cfa', 4, 'Bé nhà mình rất hợp sữa này, tiêu hóa tốt và ít bị táo bón.', 1, '5/29/2024', '7/27/2023', '1b6e76a9-cac0-47da-8e41-64f8646531ba', 'f04f091b-f47d-41f3-98d6-a0932cad13ed');
insert into ProductFeedback (id, rating, comment, isDeleted, createdDate, updatedDate, userId, productId) values ('09913036-0ef0-4508-b770-10cd4c4b7634', 5, 'Sữa này giúp mình có đủ năng lượng và dưỡng chất trong suốt thai kỳ.', 1, '5/29/2024', '7/27/2023', '8c79b700-2903-4878-8bcd-ca965cad668f', 'dc91709f-f1b3-4d0b-9b96-fd7eded0ca31');
insert into ProductFeedback (id, rating, comment, isDeleted, createdDate, updatedDate, userId, productId) values ('97c02e37-cd58-4169-b612-92ce1b6bfe97', 3, 'Bé nhà mình rất thích, ăn ngon miệng và tiêu hóa tốt.', 1, '5/29/2024', '7/27/2023', '97e33e6b-4120-4e54-8243-6644b6707b6f', '809f2ca2-d1e2-4824-85a7-4ac83039e45f');

--voucher type
insert into VoucherType(id, typeName) values ('bbc4208d-c6d4-405f-99c9-ee2f17c0b212', 'Voucher Giảm Giá Theo Phần Trăm');
insert into VoucherType(id, typeName) values ('b2645a49-584a-4156-b843-38f8d0dd5a63', 'Voucher Giảm Giá Cố Định');

--voucher
insert into voucher (id, [content], isDeleted, createdDate, updatedDate, voucherTypeId) values ('881cffa2-7c4a-48c9-96ab-85624d035fa4', '10%', 1, '5/13/2024', '4/29/2024', 'bbc4208d-c6d4-405f-99c9-ee2f17c0b212');
insert into voucher (id, [content], isDeleted, createdDate, updatedDate, voucherTypeId) values ('6f5332b3-919c-40ae-876e-aa2cc73d63d8', '25%', 1, '1/29/2024', '12/18/2023', 'bbc4208d-c6d4-405f-99c9-ee2f17c0b212');
insert into voucher (id, [content], isDeleted, createdDate, updatedDate, voucherTypeId) values ('7c31fe53-be49-4197-87e9-1b5facc00bcb', '200', 1, '5/6/2024', '11/9/2023', 'b2645a49-584a-4156-b843-38f8d0dd5a63');
insert into voucher (id, [content], isDeleted, createdDate, updatedDate, voucherTypeId) values ('110f4c38-3437-4233-af57-d88560672ae9', '100', 1, '10/21/2023', '6/15/2023', 'b2645a49-584a-4156-b843-38f8d0dd5a63');

--order
insert into [order] (id, [description], quantity, totalPrice, isDeleted, createdDate, updatedDate, userId)
values ('4098f3b1-5115-4ac9-8ad7-9a12e3ac1007', 'Đơn hàng đã được giao thành công tới khách hàng và nhận được xác nhận', 2, 200, 1, '9/6/2023', '6/25/2023', '1b6e76a9-cac0-47da-8e41-64f8646531ba');
insert into [order] (id, [description], quantity, totalPrice, isDeleted, createdDate, updatedDate, userId)
values ('62ec59be-0467-4058-893b-690f936a9a0b', 'Đơn hàng đã được giao thành công tới khách hàng và nhận được xác nhận', 1, 150, 1, '9/6/2023', '10/20/2023', '8c79b700-2903-4878-8bcd-ca965cad668f');
insert into [order] (id, [description], quantity, totalPrice, isDeleted, createdDate, updatedDate, userId)
values ('8fc4b66c-5362-42c8-aa1b-7479ff028e50', 'Đơn hàng đã được giao thành công tới khách hàng và nhận được xác nhận', 3, 510, 1, '6/26/2023', '6/26/2023', '97e33e6b-4120-4e54-8243-6644b6707b6f');
insert into [order] (id, [description], quantity, totalPrice, isDeleted, createdDate, updatedDate, userId)
values ('f911aba1-26ed-48c7-88b9-71c81752dc37', 'Đơn hàng đã được giao thành công tới khách hàng và nhận được xác nhận', 4, 1200, 1, '5/20/2024', '2/23/2024', 'a8e689b5-a1ab-4f2b-aabc-6b181e9d1a7d');

--orderxproduct
insert into orderxproduct (orderId, productId) values ('4098f3b1-5115-4ac9-8ad7-9a12e3ac1007', 'f04f091b-f47d-41f3-98d6-a0932cad13ed');
insert into orderxproduct (orderId, productId) values ('62ec59be-0467-4058-893b-690f936a9a0b', 'dc91709f-f1b3-4d0b-9b96-fd7eded0ca31');
insert into orderxproduct (orderId, productId) values ('8fc4b66c-5362-42c8-aa1b-7479ff028e50', '809f2ca2-d1e2-4824-85a7-4ac83039e45f');
insert into orderxproduct (orderId, productId) values ('f911aba1-26ed-48c7-88b9-71c81752dc37', 'c2366bd4-33b1-4a96-aed2-af4011397ae6');
