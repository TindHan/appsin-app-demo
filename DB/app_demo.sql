/*
 Navicat Premium Dump SQL

 Source Server         : mysql_localhost
 Source Server Type    : MySQL
 Source Server Version : 80018 (8.0.18)
 Source Host           : localhost:3306
 Source Schema         : app_demo

 Target Server Type    : MySQL
 Target Server Version : 80018 (8.0.18)
 File Encoding         : 65001

 Date: 19/02/2026 09:45:26
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for act_activitymain
-- ----------------------------
DROP TABLE IF EXISTS `act_activitymain`;
CREATE TABLE `act_activitymain`  (
  `actID` int(11) NOT NULL AUTO_INCREMENT,
  `actName` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `actDesc` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `actStartTime` datetime NULL DEFAULT NULL,
  `actEndTime` datetime NULL DEFAULT NULL,
  `signupStartTime` datetime NULL DEFAULT NULL,
  `signupEndTime` datetime NULL DEFAULT NULL,
  `actType` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `actWay` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `actUrl` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `actAddr` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `actMemo1` int(11) NULL DEFAULT NULL,
  `actMemo2` int(11) NULL DEFAULT NULL,
  `actMemo3` int(11) NULL DEFAULT NULL,
  `actMemo4` int(11) NULL DEFAULT NULL,
  `actMemo5` int(11) NULL DEFAULT NULL,
  `actStatus` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`actID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1029 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of act_activitymain
-- ----------------------------
INSERT INTO `act_activitymain` VALUES (1000, 'tiantian', 'sfdsafasf', '2024-09-18 09:36:38', '2024-09-18 09:36:40', '2024-09-18 09:36:41', '2024-09-18 09:36:42', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1001, 'yueyue', 'ssdfa', '2024-09-18 09:37:17', '2024-09-18 09:37:18', '2024-09-18 09:37:19', '2024-09-18 09:37:19', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1002, 'ACT1', NULL, '2024-09-23 10:47:26', '2024-09-23 10:47:50', '2024-09-23 10:47:52', '2024-09-23 10:48:07', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1003, 'ACT2', NULL, '2024-09-23 10:47:27', '2024-09-23 10:47:51', '2024-09-23 10:47:52', '2024-09-23 10:48:08', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1004, 'ACT3', NULL, '2024-09-23 10:47:27', '2024-09-23 10:47:49', '2024-09-23 10:47:53', '2024-09-23 10:48:08', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1005, 'ACT4', NULL, '2024-09-23 10:47:28', '2024-09-23 10:47:50', '2024-09-23 10:47:53', '2024-09-23 10:48:09', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1006, 'ACT5', NULL, '2024-09-23 10:47:29', '2024-09-23 10:47:48', '2024-09-23 10:47:54', '2024-09-23 10:48:09', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1007, 'ACT6', NULL, '2024-09-23 10:47:29', '2024-09-23 10:47:47', '2024-09-23 10:47:55', '2024-09-23 10:48:10', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1008, 'ACT7', NULL, '2024-09-23 10:47:30', '2024-09-23 10:47:47', '2024-09-23 10:47:55', '2024-09-23 10:48:11', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1009, 'ACT8', NULL, '2024-09-23 10:47:31', '2024-09-23 10:47:46', '2024-09-23 10:47:57', '2024-09-23 10:48:12', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1010, 'ACT9', NULL, '2024-09-23 10:47:32', '2024-09-23 10:47:45', '2024-09-23 10:47:56', '2024-09-23 10:48:12', 'online', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1011, 'ACT10', '', '2024-09-23 10:47:32', '2024-09-23 10:47:46', '2024-09-23 10:47:58', '2025-09-23 10:48:13', 'online', '', '', 'beijing city', NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1012, 'ACT11', NULL, '2024-09-23 10:47:33', '2024-09-23 10:47:44', '2024-09-23 10:47:59', '2024-09-23 10:48:13', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1013, 'ACT12', NULL, '2024-09-23 10:47:34', '2024-09-23 10:47:45', '2024-09-23 10:48:00', '2024-09-23 10:48:14', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1014, 'ACT13', NULL, '2024-09-23 10:47:34', '2024-09-23 10:47:43', '2024-09-23 10:48:01', '2024-09-23 10:48:15', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1015, 'ACT14', NULL, '2024-09-23 10:47:35', '2024-09-23 10:47:43', '2024-09-23 10:48:00', '2024-09-23 10:48:15', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1016, 'ACT15', 'for test', '2024-09-23 10:47:35', '2024-09-23 10:47:42', '2024-09-23 10:48:02', '2024-09-26 10:48:16', 'offline', '', '', 'beijing city', NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1017, 'ACT16', NULL, '2024-09-23 10:47:36', '2024-09-23 10:47:42', '2024-09-23 10:48:03', '2024-09-23 10:48:17', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1018, 'ACT17', NULL, '2024-09-23 10:47:37', '2024-09-23 10:47:40', '2024-09-23 10:48:03', '2024-09-23 10:48:18', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1019, 'ACT18', NULL, '2024-09-23 10:47:37', '2024-09-23 10:47:41', '2024-09-23 10:48:04', '2024-09-23 10:48:19', 'offline', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1020, 'ACT19', 'for test11', '2024-09-23 10:47:38', '2024-09-23 10:47:40', '2024-09-23 10:48:05', '2025-09-23 10:48:19', 'offline', '', '', '123', NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1021, 'ACT20', '', '2024-09-23 10:47:39', '2024-09-23 10:47:39', '2024-09-23 10:48:06', '2025-09-30 10:48:20', 'offline', '', '', 'beijing city', NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1022, 'ACT21', '121', '2024-09-01 14:56:00', '2024-09-30 14:56:00', '2024-09-01 14:56:00', '2024-09-04 14:56:00', 'online', NULL, NULL, 'beijing city', NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1023, 'ACT22', 'for test112233', '2025-06-02 14:57:00', '2025-12-31 14:57:00', '2025-09-01 14:57:00', '2025-12-15 14:57:00', 'online', '', '', 'beijing city', NULL, NULL, NULL, NULL, NULL, 1);
INSERT INTO `act_activitymain` VALUES (1024, 'ACT23', '12', '2024-09-16 15:00:00', '2024-09-30 15:00:00', '2024-09-01 15:00:00', '2024-09-15 15:00:00', 'online', NULL, NULL, 'beijing city', NULL, NULL, NULL, NULL, NULL, 0);
INSERT INTO `act_activitymain` VALUES (1026, 'ACT23', '12', '2024-09-16 15:25:00', '2024-09-30 15:25:00', '2024-09-01 15:25:00', '2024-09-15 15:25:00', 'offline', NULL, NULL, 'beijing city', NULL, NULL, NULL, NULL, NULL, 0);
INSERT INTO `act_activitymain` VALUES (1027, 'ACT23', '12', '2024-09-01 15:28:00', '2024-09-17 15:28:00', '2024-09-03 15:28:00', '2024-09-26 15:28:00', 'online', NULL, NULL, '123', NULL, NULL, NULL, NULL, NULL, 0);
INSERT INTO `act_activitymain` VALUES (1028, 'ACT23', '', '2024-10-01 09:50:00', '2024-10-10 17:50:00', '2024-09-01 09:51:00', '2025-12-30 21:51:00', 'online', '', '', 'Tongzhou district,beijing cityTongzhou district,beijing cityTongzhou district,beijing city', NULL, NULL, NULL, NULL, NULL, 1);

-- ----------------------------
-- Table structure for act_psnmain
-- ----------------------------
DROP TABLE IF EXISTS `act_psnmain`;
CREATE TABLE `act_psnmain`  (
  `psnPK` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `psnName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `unitPK` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `deptPK` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `postPk` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `unitName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `deptName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `postName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `psnSex` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `psnCode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `updateTime` datetime NOT NULL,
  `psnStatus` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`psnPK`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of act_psnmain
-- ----------------------------
INSERT INTO `act_psnmain` VALUES ('047BB29E-AD5F-466C-B9FF-12A86773507A', 'Tind Han', 'E52FD535-E395-519B-6E0C-5629B92AF53B', 'E52FD535-E395-519B-6E0C-5629B92AF53C', 'E52FD535-E395-519B-6E0C-5629B92AF53H', 'APPSIN Co. Ltd', 'DEPT 1 IN APPSIN', 'POST1 IN DEPT', 'male', '100000001', '2025-11-05 11:02:02', 1);
INSERT INTO `act_psnmain` VALUES ('047BB29E-AD5F-466C-B9FF-12A86773507C', 'joey', 'E52FD535-E395-519B-6E0C-5629B92AF53B', 'E52FD535-E395-519B-6E0C-5629B92AF53D', 'E52FD535-E395-519B-6E0C-5629B92AF53J', 'APPSIN Co. Ltd', 'DEPT 2 IN APPSIN', 'POST3 IN DEPT', 'other', '135487', '2025-11-05 14:49:23', 1);
INSERT INTO `act_psnmain` VALUES ('047BB29E-AD5F-466C-B9FF-12A86773507D', 'mary', 'E52FD535-E395-519B-6E0C-5629B92AF53B', 'E52FD535-E395-519B-6E0C-5629B92AF53E', 'E52FD535-E395-519B-6E0C-5629B92AF53L', 'APPSIN Co. Ltd', ' DEPT 3 IN APPSIN', 'POST5 IN DEPT', 'male', '135487999', '2024-09-29 16:15:02', 1);
INSERT INTO `act_psnmain` VALUES ('047BB29E-AD5F-466C-B9FF-12A86773507E', 'alex xu', 'E52FD535-E395-519B-6E0C-5629B92AF53B', 'E52FD535-E395-519B-6E0C-5629B92AF53E', 'E52FD535-E395-519B-6E0C-5629B92AF53L', 'APPSIN Co. Ltd', ' DEPT 3 IN APPSIN', 'POST5 IN DEPT', 'male', '100000001', '2024-09-29 16:15:02', 1);
INSERT INTO `act_psnmain` VALUES ('047BB29E-AD5F-466C-B9FF-12A86773507F', 'jodge', 'E52FD535-E395-519B-6E0C-5629B92AF53B', 'E52FD535-E395-519B-6E0C-5629B92AF53C', '', 'APPSIN Co. Ltd', 'DEPT 1 IN APPSIN', 'POST2 IN DEPT', 'male', '1354879', '2025-11-04 15:30:15', 1);
INSERT INTO `act_psnmain` VALUES ('047BB29E-AD5F-466C-B9FF-12A86773507G', 'bob lin', 'E52FD535-E395-519B-6E0C-5629B92AF53B', 'E52FD535-E395-519B-6E0C-5629B92AF53D', '', 'APPSIN Co. Ltd', 'DEPT 2 IN APPSIN', 'POST4 IN DEPT', 'female', '0000000', '2025-10-31 09:14:41', 1);
INSERT INTO `act_psnmain` VALUES ('DD5433F7-6E76-4A2C-9074-0352EC064110', 'janifer', 'E52FD535-E395-519B-6E0C-5629B92AF53M', '2E823D73-BB3A-83B0-3AE6-E74142F5A10F', '', 'Bussness Co. Ltd', 'dept 1', '', 'female', '', '2024-09-29 16:15:02', 1);

-- ----------------------------
-- Table structure for act_signup
-- ----------------------------
DROP TABLE IF EXISTS `act_signup`;
CREATE TABLE `act_signup`  (
  `signID` int(11) NOT NULL AUTO_INCREMENT,
  `actID` int(11) NULL DEFAULT NULL,
  `psnPK` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `signTime` datetime NULL DEFAULT NULL,
  `isPay` int(11) NULL DEFAULT NULL,
  `isConfirm` int(11) NULL DEFAULT NULL,
  `signStatus` int(11) NULL DEFAULT NULL,
  `signWay` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`signID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1014 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of act_signup
-- ----------------------------
INSERT INTO `act_signup` VALUES (1000, 1021, '047BB29E-AD5F-466C-B9FF-12A86773507C', '2024-09-25 16:12:43', NULL, 0, -1, 'pc_user');
INSERT INTO `act_signup` VALUES (1001, 1028, '047BB29E-AD5F-466C-B9FF-12A86773507C', '2024-09-25 16:13:41', NULL, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1002, 1016, '047BB29E-AD5F-466C-B9FF-12A86773507C', '2024-09-25 16:13:47', NULL, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1003, 1028, '047BB29E-AD5F-466C-B9FF-12A86773507A', '2024-09-29 15:57:22', 0, 0, -1, 'pc_user');
INSERT INTO `act_signup` VALUES (1004, 1028, '047BB29E-AD5F-466C-B9FF-12A86773507D', '2024-09-29 15:59:02', 0, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1005, 1028, '047BB29E-AD5F-466C-B9FF-12A86773507E', '2024-09-29 16:07:48', 0, 0, -1, 'pc_user');
INSERT INTO `act_signup` VALUES (1006, 1023, 'DD5433F7-6E76-4A2C-9074-0352EC064110', '2024-09-29 16:14:45', 0, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1007, 1023, '047BB29E-AD5F-466C-B9FF-12A86773507A', '2024-09-29 16:15:04', 0, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1008, 1020, '047BB29E-AD5F-466C-B9FF-12A86773507A', '2024-09-29 16:27:23', 0, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1009, 1019, '047BB29E-AD5F-466C-B9FF-12A86773507A', '2024-09-29 16:27:34', 0, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1010, 1021, '047BB29E-AD5F-466C-B9FF-12A86773507A', '2024-10-04 14:22:17', NULL, 1, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1011, 1021, 'pc_user', '2024-10-04 14:23:03', NULL, 1, -1, NULL);
INSERT INTO `act_signup` VALUES (1012, 1011, '047BB29E-AD5F-466C-B9FF-12A86773507A', '2024-10-04 14:28:10', NULL, 0, 1, 'pc_user');
INSERT INTO `act_signup` VALUES (1013, 1023, '047BB29E-AD5F-466C-B9FF-12A86773507C', '2025-11-05 14:34:23', NULL, 0, 1, 'pc_user');

-- ----------------------------
-- Table structure for leave_list
-- ----------------------------
DROP TABLE IF EXISTS `leave_list`;
CREATE TABLE `leave_list`  (
  `leaveID` int(11) NOT NULL AUTO_INCREMENT,
  `psnPK` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `unitName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `deptName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `postName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `leaveType` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `startTime` datetime NULL DEFAULT NULL,
  `endTime` datetime NULL DEFAULT NULL,
  `leaveDays` decimal(10, 0) NULL DEFAULT NULL,
  `createPsnPk` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `createTime` datetime NULL DEFAULT NULL,
  `approveStatus` int(11) NULL DEFAULT NULL,
  `leaveStatus` int(11) NULL DEFAULT NULL,
  `leaveReason` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  `leavePK` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL,
  PRIMARY KEY (`leaveID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of leave_list
-- ----------------------------
INSERT INTO `leave_list` VALUES (1, '047BB29E-AD5F-466C-B9FF-12A86773507C', 'APPSIN Co. Ltd', 'DEPT 2 IN APPSIN', 'POST3 IN DEPT', 'Annual Leave', '2025-11-10 08:00:00', '2025-11-14 18:00:00', 5, '047BB29E-AD5F-466C-B9FF-12A86773507C', '2025-11-04 13:01:21', 1, 1, 'Enjoy leisure time.', 'f8c5a88d-bbf9-467d-afff-397e05216d3a');
INSERT INTO `leave_list` VALUES (2, '047BB29E-AD5F-466C-B9FF-12A86773507C', 'APPSIN Co. Ltd', 'DEPT 2 IN APPSIN', 'POST3 IN DEPT', 'Sick Leave', '2025-11-07 08:00:00', '2025-11-07 18:00:00', 1, '047BB29E-AD5F-466C-B9FF-12A86773507C', '2025-11-05 11:00:17', 1, 1, 'Go to see doctor', '3c6833ed-3a87-4426-b1e3-778ee4fbc3c5');

SET FOREIGN_KEY_CHECKS = 1;
