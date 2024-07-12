--role
insert into Role (id, roleName) values ('b83f20ac-3a21-4a5f-835d-cf745c4505e5', 'Admin');
insert into Role (id, roleName) values ('d07887c4-22ca-4e13-b0ae-ca1fc97cf017', 'Staff');
insert into Role (id, roleName) values ('13cdcaa1-614f-431e-bc5b-d7bfcb483ec7', 'Member');

--[User]
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('ab7677b6-f3e1-4b3d-81d8-956f65fd85d8', 'Admin Nguyen', 'admin@gmail.com', 'admin123@', '627-496-1679', '1/21/2000', 'Female', 'PO Box 4145', 0, '11/1/2023', '9/30/2023', 'b83f20ac-3a21-4a5f-835d-cf745c4505e5');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('5768be85-7e6e-4811-8065-18b2d2521bff', 'Staff Nguyen', 'staff@gamil.com', 'staff123@', '610-460-7620', '7/17/1989', 'Male', 'Apt 1855', 0, '9/26/2023', '3/13/2024', 'd07887c4-22ca-4e13-b0ae-ca1fc97cf017');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId)
values ('a8e689b5-a1ab-4f2b-aabc-6b181e9d1a7d', 'Bobine Rushton', 'brushton2@t-online.de', 'member111@', '838-698-0355', '2/15/1990', 'Female', '9th Floor', 0, '11/6/2023', '12/25/2023', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId)
values ('840937fd-178d-4170-a9f9-e1f4fa89f816', 'Bordy Scanlan', 'boscanlan3@umich.edu', 'member222@', '713-429-3670', '6/25/2000', 'Male', 'PO Box 90749', 0, '3/17/2024', '11/2/2023', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('97e33e6b-4120-4e54-8243-6644b6707b6f', 'Jed Coldicott', 'jcoldicott4@youku.com', 'member333@', '400-886-7326', '7/20/1987', 'Male', 'PO Box 26759', 0, '4/11/2024', '2/29/2024', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('8c79b700-2903-4878-8bcd-ca965cad668f', 'Quintus Harlin', 'qharlin5@ebay.com', 'member444@', '626-340-4604', '8/16/1999', 'Male', '1st Floor', 0, '12/17/2023', '2/27/2024', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');
insert into [User] (id, fullName, email, [password], telephone, DOB, gender, [address], isDeleted, createdDate, updatedDate, roleId) 
values ('1b6e76a9-cac0-47da-8e41-64f8646531ba', 'Morna Pummell', 'mpummell6@xing.com', 'member555@', '801-995-9258', '4/20/1989', 'Female', '5th Floor', 0, '8/6/2023', '2/9/2024', '13cdcaa1-614f-431e-bc5b-d7bfcb483ec7');

--blog la staff dang
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('efda74a1-09b0-440f-b28f-d4d06feafdf8', 'How to Choose the Right Formula Milk for Your Baby', 'Choosing the right formula for your baby can be a challenge for many parents. This article will provide a detailed guide on the criteria to consider when choosing formula, including nutritional content, babys age, special needs such as allergies or lactose intolerance, and reputable brands in the market. You will be fully equipped with information to make the right decisions for your childs healthy development.', 1, '1/25/2024', '8/3/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('bd550819-ed10-41d4-bbb6-e9954776cec2', 'Nutritional Care for Pregnant Mothers: Things to Know', 'Nutrition during pregnancy plays an important role in ensuring the health of both mother and fetus. This article will provide detailed information about the essential nutrients pregnant women need to supplement, including folic acid, iron, calcium, and other vitamins. At the same time, the article will also give suggestions on daily menus and foods to avoid to ensure a healthy and safe pregnancy.', 1, '9/13/2023', '10/5/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('d6250801-7518-4588-8278-895242b875d8', 'Secrets to Help Your Baby Digest Better', 'The digestive system of young children is very sensitive and requires special care. In this article, we will share tips to help improve your babys digestive system, from choosing the right type of milk, how to mix milk properly, to building healthy eating habits. You will find useful tips to help your baby digest better and grow healthily.', 1, '10/27/2023', '12/29/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('3cb91017-0215-45d9-aa2a-ced2b3f21838', 'Organic Formula Milk: Safe Choice for Your Baby', 'Organic formula milk is becoming increasingly popular and trusted by many parents. The article will explain the benefits of organic formula milk, such as containing no preservatives, no growth hormones, and being produced from safe, non-GMO ingredients. At the same time, we will introduce some reputable organic formula milk brands so you have more choices for your baby.', 1, '7/3/2023', '3/28/2024', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('79f7cf52-f46c-48aa-9b5e-db980ab4461b', 'Signs Your Baby Needs to Change Formula', 'Recognizing the signs that your baby is not suitable for their current formula is very important to ensure your babys health. This article will help you recognize signs such as allergies, digestive disorders, or not gaining weight properly. We will also provide instructions on how to change the type of milk to be safe and effective, ensuring your baby receives the best nutrition.', 1, '3/2/2024', '6/9/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');
insert into blog (id, title, [content], isDeleted, createdDate, updatedDate, userId) 
values ('343ccc40-9dfc-4b12-8807-e8bb3ea71f06', 'Common Mistakes When Mixing Formula Milk', 'Mixing formula milk for your baby seems simple, but there can be many mistakes if you are not careful. This article will list common mistakes that parents often make when mixing formula, such as not having the correct ratio of water and milk powder, using water that is too hot or too cold, and not cleaning the utensils. tools to mix milk properly. We will also offer solutions to overcome these errors, ensuring your baby receives full nutrition from milk.', 1, '3/11/2024', '10/2/2023', '5768BE85-7E6E-4811-8065-18B2D2521BFF');

--product type
insert into [ProductType] (id, productType) values ('a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f', 'Milk for Baby');
insert into [ProductType] (id, productType) values ('336d6005-a320-498a-8a1d-cc42f07a15d9', 'Milk for Pregnant Mothers');
insert into [ProductType] (id, productType) values ('281d84e6-3c79-4d9c-bbfa-53df3692c486', 'Nutritious Baby Food');

--product
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId)
values ('f04f091b-f47d-41f3-98d6-a0932cad13ed', 'HiPP', 'HiPP HA Dutch Stage 1 Hydrolyzed Formula (0-6 months) 800g', 'Formula milk for infants provides essential nutrients such as easily digestible whey protein, DHA, ARA, and important vitamins and minerals to help support the babys brain, vision and immune system development.', 10, 100, 0, '9/7/2023', '10/6/2023', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('ba7325bd-0f1d-4f5c-a260-d3221e8bceb1', 'HiPP', 'HiPP Dutch Stage 2 Combiotic Organic Infant Milk Formula (6-12 Months) 800g', 'Formula milk for children from 6-12 months adds protein, iron, calcium and B vitamins to support growth, bone development and nervous system, while strengthening the digestive and immune systems with probiotics.', 20, 200, 0, '8/8/2023', '10/8/2023', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('0c0f9f3d-1448-40ee-b058-9dd1b6eabfcc', 'HiPP', 'HiPP Dutch Stage 3 Combiotic Organic Infant Milk Formula (12+ Months) 800g', 'Formula milk for children over 1 year old provides calcium, vitamin D, DHA and other essential nutrients to help develop bones, teeth and brain, while also supplementing energy and supporting a healthy digestive system.', 14, 300, 0, '8/21/2023', '7/28/2023', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659e6', 'HiPP', 'HiPP German Stage 1 Organic Combiotic Milk Formula (0-6 Months) 600g', 'Special formulas are for babies with special needs such as cows milk protein allergy, lactose intolerance, or who want to use organic milk. The product provides complete nutrients, ensures safety and is suitable for your babys health.', 4, 180, 0, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659e5', 'HiPP', 'HiPP German Stage 2 Organic Combiotic Follow On Formula (6+ Months) 600g', 'Amino acid-based formula is recommended for babies with severe allergies or intolerances to both cows milk and soy. It contains purified amino acids, which are the building blocks of protein, making it highly digestible and hypoallergenic.', 4, 259, 0, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659e4', 'HiPP', 'HiPP German Stage 3 Combiotic Organic Growing Up Milk Formula (10+ Months) 600g', 'Organic goat milk formula provides an alternative to cows milk for babies with sensitivities or for parents seeking organic options. It offers complete nutrition and is easier to digest for some babies compared to cows milk formulas.', 4, 270, 0, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');

insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659d1', 'Kendamil', 'Kendamil Stage 1 Organic UK First Infant Milk Formula (0-6 Months) 800g', 'Specialized formulas are available for babies with specific metabolic disorders, such as phenylketonuria (PKU) or galactosemia. These formulas are carefully formulated to meet unique dietary needs and ensure safe growth and development.', 4, 190, 0, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659d2', 'Kendamil', 'Kendamil Stage 2 Organic UK Follow on Milk Formula (6-12 Months) 800g', 'Enfamil Gentlease is a gentle formula designed for babies with fussiness, gas, or crying. It features easy-to-digest proteins and reduced lactose, promoting softer stools and easing digestion for sensitive tummies.', 4, 400, 0, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659d3', 'Kendamil', 'Kendamil Classic Stage 1 First Infant Milk Formula (0-6 Months) 800g', 'Formula specially formulated for premature babies provides extra nutrients and calories needed for their rapid growth and development. It supports healthy weight gain and ensures optimal nutrition during this critical stage.', 4, 900, 0, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659d4', 'Kendamil', 'Kendamil Classic Stage 2 Follow-On Milk Formula (6-12 Months) 800g', 'Whole milk (full-fat) is recommended for children under two years old to support brain development and growth. After age two, pediatricians may recommend switching to reduced-fat (2%) milk to reduce saturated fat intake while still providing essential nutrients.', 4, 390, 0, '1/9/2024', '1/29/2024', 'a6caa91e-83d3-49d7-a8ed-cf5e5415ee8f');

insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('93ee40dd-af8e-4605-9b61-9b785fe659d5', 'Enfamama A+', 'Enfamama A+ Powder Milk with 360° Brain Plus - Chocolate Flavor - 400g', 'During pregnancy, a womans calcium requirements increase to support the developing babys skeletal system. Milk is a primary source of calcium, helping to prevent maternal bone loss and ensuring optimal bone development for the baby.', 4, 480, 0, '1/9/2024', '1/29/2024', '336d6005-a320-498a-8a1d-cc42f07a15d9');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('dc91709f-f1b3-4d0b-9b96-fd7eded0ca31', 'Enfamama A+', 'Enfamama A+ Powder Milk with 360° Brain Plus - Vanilla Flavor - 400g', 'Pregnant milk provides essential nutrients such as protein, vitamins, and minerals to help pregnant mothers maintain their health and support the comprehensive development of the fetus.', 15, 150, 0, '11/16/2023', '11/5/2023', '336d6005-a320-498a-8a1d-cc42f07a15d9');

insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('b4339254-6294-49bc-a571-7ca630e64bd8', 'Similac', 'Similac Mom Vanilla Flavor Milk, 900g', 'Pregnant milk rich in calcium helps pregnant mothers improve bone and teeth health, while supporting the development of the fetus skeletal system, preventing postpartum osteoporosis.', 23, 250, 0, '5/8/2024', '11/30/2023', '336d6005-a320-498a-8a1d-cc42f07a15d9');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('c2366bd4-33b1-4a96-aed2-af4011397ae6', 'Similac', 'Similac Mom Vanilla Flavor Milk, 400g', 'Pregnant milk rich in DHA supports fetal brain and vision development, while also helping to improve memory and reduce stress for pregnant mothers during pregnancy.', 8, 300, 0, '8/7/2023', '9/2/2023', '336d6005-a320-498a-8a1d-cc42f07a15d9');

insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('809f2ca2-d1e2-4824-85a7-4ac83039e45f', 'Vinamilk', 'Ridielac Gold Rice Milk Infant Cereal - 350g', 'Weaning powder for babies 4-6 months has a balanced nutritional composition, is easy to digest, helps supplement essential nutrients for development and strengthens the babys immune system.', 16, 180, 0, '2/16/2024', '7/6/2023', '281d84e6-3c79-4d9c-bbfa-53df3692c486');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('248125dc-92f9-42bb-9238-3e5794022d84', 'Vinamilk', 'Ridielac Gold Salmon and Broccoli Infant Cereal - 350g', 'Weaning powder for children 6-12 months is supplemented with vitamins and minerals, helping your baby develop comprehensively physically and mentally during the weaning period.', 12, 220, 0, '7/28/2023', '11/12/2023', '281d84e6-3c79-4d9c-bbfa-53df3692c486');
insert into product (id, brand, [name], [description], stockQuantity, price, isDeleted, createdDate, updatedDate, productTypeId) 
values ('79c63cb3-772e-4b59-b9e5-ccbb2bc30bdf', 'Vinamilk', 'Ridielac Gold Beef and Vegetable Infant Cereal - 350g', 'Organic weaning powder is made from natural ingredients, does not contain chemicals and preservatives, ensuring safety and providing adequate nutrition for your baby.', 16, 190, 0, '10/27/2023', '10/23/2023', '281d84e6-3c79-4d9c-bbfa-53df3692c486');

--product feedback
insert into ProductFeedback (id, rating, comment, isDeleted, createdDate, updatedDate, userId, productId) values ('0c9d521c-5ce9-4bc3-b9e5-ea4224523cfa', 4, 'My baby is very compatible with this milk, digests well and rarely gets constipated.', 0, '5/29/2024', '7/27/2023', '1b6e76a9-cac0-47da-8e41-64f8646531ba', 'f04f091b-f47d-41f3-98d6-a0932cad13ed');
insert into ProductFeedback (id, rating, comment, isDeleted, createdDate, updatedDate, userId, productId) values ('09913036-0ef0-4508-b770-10cd4c4b7634', 5, 'This milk helps me have enough energy and nutrients throughout my pregnancy.', 0, '5/29/2024', '7/27/2023', '8c79b700-2903-4878-8bcd-ca965cad668f', 'dc91709f-f1b3-4d0b-9b96-fd7eded0ca31');
insert into ProductFeedback (id, rating, comment, isDeleted, createdDate, updatedDate, userId, productId) values ('97c02e37-cd58-4169-b612-92ce1b6bfe97', 4, 'My baby loves it, has good appetite and good digestion.', 0, '5/29/2024', '7/27/2023', '97e33e6b-4120-4e54-8243-6644b6707b6f', '809f2ca2-d1e2-4824-85a7-4ac83039e45f');

--voucher type
insert into VoucherType(id, typeName) values ('bbc4208d-c6d4-405f-99c9-ee2f17c0b212', 'Percentage Discount Voucher');
insert into VoucherType(id, typeName) values ('b2645a49-584a-4156-b843-38f8d0dd5a63', 'Fixed Discount Voucher');

--voucher
insert into voucher (id,[vouchername] ,content, condition,StartDate,EndDate,isDeleted, createdDate, updatedDate, voucherTypeId) values ('881cffa2-7c4a-48c9-96ab-85624d035fa4','20% discount' ,20, 200,'7/8/2024', '8/8/2024', 1, '5/13/2024', '4/29/2024', 'bbc4208d-c6d4-405f-99c9-ee2f17c0b212');
insert into voucher (id, [vouchername],content, condition,StartDate,EndDate,isDeleted, createdDate, updatedDate, voucherTypeId) values ('6f5332b3-919c-40ae-876e-aa2cc73d63d8','30% discount' , 30, 200,'7/8/2024', '8/8/2024', 0, '1/29/2024', '12/18/2023', 'bbc4208d-c6d4-405f-99c9-ee2f17c0b212');
insert into voucher (id, [vouchername],content, condition,StartDate,EndDate,isDeleted, createdDate, updatedDate, voucherTypeId) values ('7c31fe53-be49-4197-87e9-1b5facc00bcb','40$ discount' , 40, 200,'7/8/2024', '8/8/2024', 0, '5/6/2024', '11/9/2023', 'b2645a49-584a-4156-b843-38f8d0dd5a63');
insert into voucher (id, [vouchername],content, condition,StartDate,EndDate,isDeleted, createdDate, updatedDate, voucherTypeId) values ('110f4c38-3437-4233-af57-d88560672ae9','50$ discount' , 50, 200, '7/8/2024', '8/8/2024',1, '10/21/2023', '6/15/2023', 'b2645a49-584a-4156-b843-38f8d0dd5a63');

--order
insert into [order] (id, [description], totalPrice, [status], createdDate, updatedDate, userId)
values ('4098f3b1-5115-4ac9-8ad7-9a12e3ac1007', 'The order has been successfully delivered to the customer and confirmation has been received', 1680, 'Completed', '9/6/2023', '6/25/2023', '1b6e76a9-cac0-47da-8e41-64f8646531ba');
insert into [order] (id, [description], totalPrice, [status], createdDate, updatedDate, userId)
values ('62ec59be-0467-4058-893b-690f936a9a0b', 'The order has been successfully delivered to the customer and confirmation has been received', 200, 'Completed', '9/6/2023', '10/20/2023', '8c79b700-2903-4878-8bcd-ca965cad668f');
insert into [order] (id, [description], totalPrice, [status], createdDate, updatedDate, userId)
values ('8fc4b66c-5362-42c8-aa1b-7479ff028e50', 'The order has been successfully delivered to the customer and confirmation has been received', 360, 'Completed', '6/26/2023', '6/26/2023', '97e33e6b-4120-4e54-8243-6644b6707b6f');
insert into [order] (id, [description], totalPrice, [status], createdDate, updatedDate, userId)
values ('f911aba1-26ed-48c7-88b9-71c81752dc37', 'The order has been successfully delivered to the customer and confirmation has been received', 1170, 'Completed', '5/20/2024', '2/23/2024', 'a8e689b5-a1ab-4f2b-aabc-6b181e9d1a7d');

--orderxproduct
insert into orderxproduct (orderId, productId, quantity) values ('4098f3b1-5115-4ac9-8ad7-9a12e3ac1007', 'f04f091b-f47d-41f3-98d6-a0932cad13ed', 1);
insert into orderxproduct (orderId, productId, quantity) values ('4098f3b1-5115-4ac9-8ad7-9a12e3ac1007', '93ee40dd-af8e-4605-9b61-9b785fe659d1', 2);
insert into orderxproduct (orderId, productId, quantity) values ('4098f3b1-5115-4ac9-8ad7-9a12e3ac1007', 'c2366bd4-33b1-4a96-aed2-af4011397ae6', 4);

insert into orderxproduct (orderId, productId, quantity) values ('62ec59be-0467-4058-893b-690f936a9a0b', 'ba7325bd-0f1d-4f5c-a260-d3221e8bceb1', 1);

insert into orderxproduct (orderId, productId, quantity) values ('8fc4b66c-5362-42c8-aa1b-7479ff028e50', '809f2ca2-d1e2-4824-85a7-4ac83039e45f', 2);

insert into orderxproduct (orderId, productId, quantity) values ('f911aba1-26ed-48c7-88b9-71c81752dc37', 'c2366bd4-33b1-4a96-aed2-af4011397ae6', 2);
insert into orderxproduct (orderId, productId, quantity) values ('f911aba1-26ed-48c7-88b9-71c81752dc37', '79c63cb3-772e-4b59-b9e5-ccbb2bc30bdf', 3);
