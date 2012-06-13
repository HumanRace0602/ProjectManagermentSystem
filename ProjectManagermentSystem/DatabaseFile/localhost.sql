-- phpMyAdmin SQL Dump
-- version 3.3.9
-- http://www.phpmyadmin.net
--
-- 主机: localhost
-- 生成日期: 2012 年 06 月 13 日 12:39
-- 服务器版本: 5.5.8
-- PHP 版本: 5.3.5

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- 数据库: `projectmanagermentsystem`
--
CREATE DATABASE `projectmanagermentsystem` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `projectmanagermentsystem`;

-- --------------------------------------------------------

--
-- 表的结构 `projecttable`
--

CREATE TABLE IF NOT EXISTS `projecttable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `projectname` varchar(50) NOT NULL,
  `projectcontext` varchar(200) NOT NULL,
  `projectdate` datetime NOT NULL,
  `ispass` tinyint(4) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=20 ;

--
-- 转存表中的数据 `projecttable`
--

INSERT INTO `projecttable` (`id`, `projectname`, `projectcontext`, `projectdate`, `ispass`) VALUES
(5, '2', 'second', '2012-05-29 13:11:39', 0),
(6, '3', '33333333', '2012-05-29 13:14:39', 0),
(7, '4', '444444', '2012-05-29 13:16:59', 0),
(8, '555', '444', '2012-05-29 13:19:37', 0),
(9, '6666666666', 'ddddddddddddddddddd', '2012-05-29 13:25:55', 0),
(10, 'eee', 'wwww', '2012-05-29 13:32:43', 0),
(11, '123', '123', '2012-05-29 19:54:10', 0),
(12, 'Human Project', 'It''s my Project', '2012-06-11 16:25:56', 0),
(13, '12222222', '1222222', '2012-06-11 16:34:01', 0),
(14, '333333', '33333333', '2012-06-11 16:39:46', 0),
(15, '12321', '2321312', '2012-06-11 16:40:51', 0),
(16, 'Hill''s Project', 'It''s Hill''s Project', '2012-06-12 22:54:31', 0),
(17, 'qqqqqq', 'qqqqqqq', '2012-06-12 23:02:03', 0),
(18, 'wwwwwwwwwwww', 'wwwwwwwww', '2012-06-12 23:04:39', 0),
(19, 'eeeeeeeee', 'eeeeee', '2012-06-12 23:05:53', 0);

-- --------------------------------------------------------

--
-- 表的结构 `roletable`
--

CREATE TABLE IF NOT EXISTS `roletable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `rolename` varchar(10) NOT NULL,
  `rolemen` varchar(25) NOT NULL,
  `pr_id` int(11) NOT NULL,
  `state` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=39 ;

--
-- 转存表中的数据 `roletable`
--

INSERT INTO `roletable` (`id`, `rolename`, `rolemen`, `pr_id`, `state`) VALUES
(3, 'Admin', 'Hill', 10, NULL),
(4, 'Admin', 'Hill', 11, NULL),
(5, 'Request', 'zhangsan', 11, 'Unknown'),
(6, 'Execute', 'Human', 11, 'Yes'),
(7, 'Admin', 'Human', 12, NULL),
(8, 'Request', 'Hill', 12, 'No'),
(9, 'Admin', 'Human', 13, NULL),
(10, 'Admin', 'Human', 14, NULL),
(11, 'Admin', 'Human', 15, NULL),
(12, 'Request', 'Hill', 15, 'Yes'),
(13, 'Execute', 'zhangsan', 15, 'Unknown'),
(14, 'Execute', 'Human', 15, 'Yes'),
(15, 'Admin', 'Hill', 6, NULL),
(16, 'Admin', 'Hill', 6, NULL),
(17, 'Admin', 'Hill', 6, NULL),
(18, 'Admin', 'Hill', 6, NULL),
(19, 'Admin', 'Hill', 6, NULL),
(20, 'Admin', 'Hill', 6, NULL),
(21, 'Admin', 'Hill', 6, NULL),
(22, 'Admin', 'Hill', 6, NULL),
(23, 'Admin', 'Hill', 16, NULL),
(24, 'Request', 'Hill', 16, 'Yes'),
(25, 'Execute', 'Hill', 16, 'Yes'),
(26, 'Execute', 'zhangsan', 16, 'Unknown'),
(27, 'Admin', 'Human', 17, NULL),
(28, 'Request', 'Human', 17, 'Yes'),
(29, 'Execute', 'Human', 17, 'Yes'),
(30, 'Execute', 'Hill', 17, 'Yes'),
(31, 'Admin', 'Human', 18, NULL),
(32, 'Request', 'Human', 18, 'Yes'),
(33, 'Execute', 'Human', 18, 'Yes'),
(34, 'Execute', '', 18, 'Unknown'),
(35, 'Admin', 'Human', 19, NULL),
(36, 'Request', 'Human', 19, 'Yes'),
(37, 'Execute', 'Human', 19, 'Yes'),
(38, 'Execute', 'Hill', 19, 'Yes');

-- --------------------------------------------------------

--
-- 表的结构 `usertable`
--

CREATE TABLE IF NOT EXISTS `usertable` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `email` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- 转存表中的数据 `usertable`
--

INSERT INTO `usertable` (`id`, `username`, `password`, `email`) VALUES
(1, 'Hill', 'hz2006', 'human0602@qq.com'),
(2, 'zhangsan', '123', '123@11.com'),
(3, 'Hill1', 'D27BF1B43760386E8490A93A9', 'human0602@qq.com'),
(4, '2009051713', 'D27BF1B43760386E8490A93A9', '123@123.com'),
(5, 'Human', 'hz2006', '136249351@11.com');
