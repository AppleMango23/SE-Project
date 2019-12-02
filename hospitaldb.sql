-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 01, 2019 at 03:36 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospitaldb`
--

-- --------------------------------------------------------

--
-- Table structure for table `bedside`
--

CREATE TABLE `bedside` (
  `bedsideId` int(11) NOT NULL,
  `wing` varchar(20) NOT NULL,
  `floor` varchar(10) NOT NULL,
  `bay` varchar(10) NOT NULL,
  `bed` varchar(10) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `patientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bedside`
--

INSERT INTO `bedside` (`bedsideId`, `wing`, `floor`, `bay`, `bed`, `status`, `patientId`) VALUES
(1, 'East Wing', 'Floor 1', 'Bay A', 'Bed 1', 1, 1),
(2, 'East Wing', 'Floor 1', 'Bay A', 'Bed 2', 1, 2),
(3, 'East Wing', 'Floor 1', 'Bay A', 'Bed 3', 0, 0),
(4, 'East Wing', 'Floor 1', 'Bay A', 'Bed 4', 0, 0),
(5, 'East Wing', 'Floor 1', 'Bay A', 'Bed 5', 0, 0),
(6, 'East Wing', 'Floor 1', 'Bay A', 'Bed 6', 0, 0),
(7, 'East Wing', 'Floor 1', 'Bay A', 'Bed 7', 0, 0),
(8, 'East Wing', 'Floor 1', 'Bay A', 'Bed 8', 0, 0),
(9, 'East Wing', 'Floor 1', 'Bay B', 'Bed 1', 0, 0),
(10, 'East Wing', 'Floor 1', 'Bay B', 'Bed 2', 0, 0),
(11, 'East Wing', 'Floor 1', 'Bay B', 'Bed 3', 0, 0),
(12, 'East Wing', 'Floor 1', 'Bay B', 'Bed 4', 0, 0),
(13, 'East Wing', 'Floor 1', 'Bay B', 'Bed 5', 0, 0),
(14, 'East Wing', 'Floor 1', 'Bay B', 'Bed 6', 0, 0),
(15, 'East Wing', 'Floor 1', 'Bay B', 'Bed 7', 0, 0),
(16, 'East Wing', 'Floor 1', 'Bay B', 'Bed 8', 0, 0),
(17, 'East Wing', 'Floor 2', 'Bay A', 'Bed 1', 0, 0),
(18, 'East Wing', 'Floor 2', 'Bay A', 'Bed 2', 0, 0),
(19, 'East Wing', 'Floor 2', 'Bay A', 'Bed 3', 0, 0),
(20, 'East Wing', 'Floor 2', 'Bay A', 'Bed 4', 0, 0),
(21, 'East Wing', 'Floor 2', 'Bay A', 'Bed 5', 0, 0),
(22, 'East Wing', 'Floor 2', 'Bay A', 'Bed 6', 0, 0),
(23, 'East Wing', 'Floor 2', 'Bay A', 'Bed 7', 0, 0),
(24, 'East Wing', 'Floor 2', 'Bay A', 'Bed 8', 0, 0),
(25, 'East Wing', 'Floor 2', 'Bay B', 'Bed 1', 0, 0),
(26, 'East Wing', 'Floor 2', 'Bay B', 'Bed 2', 0, 0),
(27, 'East Wing', 'Floor 2', 'Bay B', 'Bed 3', 0, 0),
(28, 'East Wing', 'Floor 2', 'Bay B', 'Bed 4', 0, 0),
(29, 'East Wing', 'Floor 2', 'Bay B', 'Bed 5', 0, 0),
(30, 'East Wing', 'Floor 2', 'Bay B', 'Bed 6', 0, 0),
(31, 'East Wing', 'Floor 2', 'Bay B', 'Bed 7', 0, 0),
(32, 'East Wing', 'Floor 2', 'Bay B', 'Bed 8', 0, 0),
(33, 'West Wing', 'Floor 1', 'Bay A', 'Bed 1', 0, 0),
(34, 'West Wing', 'Floor 1', 'Bay A', 'Bed 2', 0, 0),
(35, 'West Wing', 'Floor 1', 'Bay A', 'Bed 3', 0, 0),
(36, 'West Wing', 'Floor 1', 'Bay A', 'Bed 4', 0, 0),
(37, 'West Wing', 'Floor 1', 'Bay A', 'Bed 5', 0, 0),
(38, 'West Wing', 'Floor 1', 'Bay A', 'Bed 6', 0, 0),
(39, 'West Wing', 'Floor 1', 'Bay A', 'Bed 7', 0, 0),
(40, 'West Wing', 'Floor 1', 'Bay A', 'Bed 8', 0, 0),
(41, 'West Wing', 'Floor 1', 'Bay B', 'Bed 1', 0, 0),
(42, 'West Wing', 'Floor 1', 'Bay B', 'Bed 2', 0, 0),
(43, 'West Wing', 'Floor 1', 'Bay B', 'Bed 3', 0, 0),
(44, 'West Wing', 'Floor 1', 'Bay B', 'Bed 4', 0, 0),
(45, 'West Wing', 'Floor 1', 'Bay B', 'Bed 5', 0, 0),
(46, 'West Wing', 'Floor 1', 'Bay B', 'Bed 6', 0, 0),
(47, 'West Wing', 'Floor 1', 'Bay B', 'Bed 7', 0, 0),
(48, 'West Wing', 'Floor 1', 'Bay B', 'Bed 8', 0, 0),
(49, 'West Wing', 'Floor 2', 'Bay A', 'Bed 1', 0, 0),
(50, 'West Wing', 'Floor 2', 'Bay A', 'Bed 2', 0, 0),
(51, 'West Wing', 'Floor 2', 'Bay A', 'Bed 3', 0, 0),
(52, 'West Wing', 'Floor 2', 'Bay A', 'Bed 4', 0, 0),
(53, 'West Wing', 'Floor 2', 'Bay A', 'Bed 5', 0, 0),
(54, 'West Wing', 'Floor 2', 'Bay A', 'Bed 6', 0, 0),
(55, 'West Wing', 'Floor 2', 'Bay A', 'Bed 7', 0, 0),
(56, 'West Wing', 'Floor 2', 'Bay A', 'Bed 8', 0, 0),
(57, 'West Wing', 'Floor 2', 'Bay B', 'Bed 1', 0, 0),
(58, 'West Wing', 'Floor 2', 'Bay B', 'Bed 2', 0, 0),
(59, 'West Wing', 'Floor 2', 'Bay B', 'Bed 3', 0, 0),
(60, 'West Wing', 'Floor 2', 'Bay B', 'Bed 4', 0, 0),
(61, 'West Wing', 'Floor 2', 'Bay B', 'Bed 5', 0, 0),
(62, 'West Wing', 'Floor 2', 'Bay B', 'Bed 6', 0, 0),
(63, 'West Wing', 'Floor 2', 'Bay B', 'Bed 7', 0, 0),
(64, 'West Wing', 'Floor 2', 'Bay B', 'Bed 8', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `medicalstaff`
--

CREATE TABLE `medicalstaff` (
  `id` int(11) NOT NULL,
  `staffId` varchar(10) NOT NULL,
  `staffName` varchar(50) NOT NULL,
  `password` varchar(25) NOT NULL,
  `careerType` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `contactNumber` varchar(15) NOT NULL,
  `pagerNumber` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `medicalstaff`
--

INSERT INTO `medicalstaff` (`id`, `staffId`, `staffName`, `password`, `careerType`, `email`, `contactNumber`, `pagerNumber`) VALUES
(1, 'D1', 'Steve', '123', 'Doctor', 'steve@mail.com', '122', '124'),
(2, 'D2', 'Noah', '132', 'Consultant', 'noah@mail.com', '321', '1145');

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE `messages` (
  `id` int(11) NOT NULL,
  `staffId` varchar(255) NOT NULL,
  `location` varchar(255) NOT NULL,
  `patient` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `dataAndTimeAlert` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `modulesreading`
--

CREATE TABLE `modulesreading` (
  `modulesReadingId` int(11) NOT NULL,
  `patientId` int(11) NOT NULL,
  `pulseRMin` int(255) NOT NULL,
  `pulseRMax` int(255) NOT NULL,
  `pulseRIntTime` int(10) NOT NULL,
  `PRmodifiedTime` varchar(255) NOT NULL,
  `breathRMin` int(255) NOT NULL,
  `breathRMax` int(255) NOT NULL,
  `breathRIntTime` int(10) NOT NULL,
  `BRmodifiedTime` varchar(255) NOT NULL,
  `systolicMin` int(255) NOT NULL,
  `systolicMax` int(255) NOT NULL,
  `diastolicMin` int(255) NOT NULL,
  `diastolicMax` int(255) NOT NULL,
  `bloodPIntTime` int(11) NOT NULL,
  `BPmodifiedTime` varchar(255) NOT NULL,
  `tempMin` float NOT NULL,
  `tempMax` float NOT NULL,
  `tempIntTime` int(10) NOT NULL,
  `TEMPmodifiedTime` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `modulesreading`
--

INSERT INTO `modulesreading` (`modulesReadingId`, `patientId`, `pulseRMin`, `pulseRMax`, `pulseRIntTime`, `PRmodifiedTime`, `breathRMin`, `breathRMax`, `breathRIntTime`, `BRmodifiedTime`, `systolicMin`, `systolicMax`, `diastolicMin`, `diastolicMax`, `bloodPIntTime`, `BPmodifiedTime`, `tempMin`, `tempMax`, `tempIntTime`, `TEMPmodifiedTime`) VALUES
(1, 1, 60, 100, 1, '11/30/2019 3:01:05 PM', 12, 20, 2, '11/30/2019 3:01:05 PM', 80, 120, 60, 80, 3, '11/30/2019 3:01:05 PM', 35.2, 36.9, 5, '11/30/2019 3:01:05 PM'),
(2, 1, 70, 110, 2, '11/30/2019 3:01:05 PM', 13, 21, 2, '11/30/2019 3:01:05 PM', 70, 110, 65, 85, 4, '11/30/2019 3:01:05 PM', 35.2, 36.9, 5, '11/30/2019 3:01:05 PM'),
(3, 1, 70, 110, 2, '11/30/2019 3:58:22 PM', 13, 21, 2, '11/30/2019 3:58:22 PM', 70, 110, 65, 85, 4, '11/30/2019 3:58:22 PM', 35.2, 36.9, 5, '11/30/2019 3:58:22 PM'),
(4, 1, 71, 110, 2, '11/30/2019 4:05:16 PM', 13, 21, 2, '11/30/2019 4:05:16 PM', 70, 110, 65, 85, 4, '11/30/2019 4:05:16 PM', 35.2, 36.9, 5, '11/30/2019 4:05:16 PM'),
(5, 2, 60, 100, 1, '11/30/2019 6:13:29 PM', 12, 21, 2, '11/30/2019 6:13:29 PM', 80, 120, 60, 80, 3, '11/30/2019 6:13:29 PM', 35.2, 36.9, 5, '11/30/2019 6:13:29 PM');

-- --------------------------------------------------------

--
-- Table structure for table `onshift`
--

CREATE TABLE `onshift` (
  `onShiftId` int(255) NOT NULL,
  `staffId` varchar(255) NOT NULL,
  `dateOnShift` varchar(255) NOT NULL,
  `timeOnShift` varchar(255) NOT NULL,
  `dateAndTimeRegistered` varchar(255) NOT NULL,
  `dateAndTimeDeregistered` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `onshift`
--

INSERT INTO `onshift` (`onShiftId`, `staffId`, `dateOnShift`, `timeOnShift`, `dateAndTimeRegistered`, `dateAndTimeDeregistered`) VALUES
(1, 'D1', '01/12/2019', '00:00 - 00:59', '12/1/2019 1:36:17 AM', '12/1/2019 4:29:36 PM'),
(2, 'D1', '01/12/2019', '02:00 - 02:59', '12/1/2019 1:36:18 AM', '-'),
(3, 'D1', '01/12/2019', '07:00 - 07:59', '12/1/2019 1:36:18 AM', '12/1/2019 8:28:23 PM'),
(4, 'D1', '01/12/2019', '10:00 - 10:59', '12/1/2019 1:36:18 AM', '12/1/2019 8:30:50 PM'),
(5, 'D1', '01/12/2019', '12:00 - 12:59', '12/1/2019 1:36:18 AM', '-'),
(6, 'D1', '01/12/2019', '22:00 - 22:59', '12/1/2019 1:36:18 AM', '-'),
(7, 'D2', '01/12/2019', '00:00 - 00:59', '12/1/2019 3:55:06 PM', '12/1/2019 8:29:20 PM'),
(8, 'D2', '01/12/2019', '06:00 - 06:59', '12/1/2019 3:55:06 PM', '-'),
(9, 'D2', '01/12/2019', '16:00 - 16:59', '12/1/2019 3:55:06 PM', '-'),
(10, 'D2', '01/12/2019', '02:00 - 02:59', '12/1/2019 8:07:20 PM', '12/1/2019 8:20:44 PM'),
(11, 'D2', '01/12/2019', '07:00 - 07:59', '12/1/2019 8:07:51 PM', '12/1/2019 8:07:58 PM');

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `patientId` int(11) NOT NULL,
  `patientName` varchar(50) NOT NULL,
  `patientAge` int(150) NOT NULL,
  `patientGender` varchar(10) NOT NULL,
  `bedsideId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patient`
--

INSERT INTO `patient` (`patientId`, `patientName`, `patientAge`, `patientGender`, `bedsideId`) VALUES
(1, 'Testing', 100, 'Male', 1),
(2, 'Hello', 1, 'Female', 2);

-- --------------------------------------------------------

--
-- Table structure for table `patientreadings`
--

CREATE TABLE `patientreadings` (
  `patientReadingId` int(11) NOT NULL,
  `patientId` int(11) NOT NULL,
  `pulseRate` int(255) NOT NULL,
  `breathingRate` int(255) NOT NULL,
  `systolic` int(255) NOT NULL,
  `diastolic` int(255) NOT NULL,
  `temperature` float NOT NULL,
  `dateAndTime` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `patientreadings`
--

INSERT INTO `patientreadings` (`patientReadingId`, `patientId`, `pulseRate`, `breathingRate`, `systolic`, `diastolic`, `temperature`, `dateAndTime`) VALUES
(1, 1, 0, 0, 0, 0, 0, '11/30/2019 6:09:57 PM'),
(2, 1, 0, 0, 0, 0, 0, '11/30/2019 6:09:59 PM'),
(3, 1, 0, 0, 0, 0, 0, '11/30/2019 6:09:59 PM'),
(4, 1, 0, 0, 0, 0, 0, '11/30/2019 6:10:00 PM'),
(5, 1, 0, 0, 0, 0, 0, '11/30/2019 6:10:01 PM'),
(6, 1, 1, 1, 1, 1, 1, '11/30/2019 6:10:02 PM'),
(7, 1, 2, 2, 2, 2, 2, '11/30/2019 6:10:03 PM'),
(8, 1, 3, 3, 3, 3, 3, '11/30/2019 6:10:04 PM'),
(9, 1, 4, 4, 4, 4, 4, '11/30/2019 6:10:05 PM'),
(10, 1, 5, 5, 5, 5, 5, '11/30/2019 6:10:06 PM'),
(11, 1, 6, 6, 6, 6, 6, '11/30/2019 6:10:07 PM'),
(12, 1, 7, 7, 7, 7, 7, '11/30/2019 6:10:08 PM'),
(13, 1, 8, 8, 8, 8, 8, '11/30/2019 6:10:09 PM'),
(14, 1, 9, 9, 9, 9, 9, '11/30/2019 6:10:10 PM'),
(15, 1, 10, 10, 10, 10, 10, '11/30/2019 6:10:11 PM'),
(16, 1, 11, 11, 11, 11, 11, '11/30/2019 6:10:12 PM'),
(17, 1, 12, 12, 12, 12, 12, '11/30/2019 6:10:13 PM'),
(18, 1, 13, 13, 13, 13, 13, '11/30/2019 6:10:14 PM'),
(19, 1, 14, 14, 14, 14, 14, '11/30/2019 6:10:15 PM'),
(20, 1, 15, 15, 15, 15, 15, '11/30/2019 6:10:16 PM'),
(21, 1, 16, 16, 16, 16, 16, '11/30/2019 6:10:17 PM'),
(22, 1, 17, 17, 17, 17, 17, '11/30/2019 6:10:18 PM'),
(23, 1, 18, 18, 18, 18, 18, '11/30/2019 6:10:19 PM'),
(24, 1, 19, 19, 19, 19, 19, '11/30/2019 6:10:20 PM'),
(25, 1, 20, 20, 20, 20, 20, '11/30/2019 6:10:21 PM'),
(26, 1, 21, 21, 21, 21, 21, '11/30/2019 6:10:22 PM'),
(27, 1, 22, 22, 22, 22, 22, '11/30/2019 6:10:23 PM'),
(28, 1, 0, 0, 0, 0, 0, '11/30/2019 6:11:56 PM'),
(29, 1, 0, 0, 0, 0, 0, '11/30/2019 6:11:57 PM'),
(30, 1, 0, 0, 0, 0, 0, '11/30/2019 6:11:58 PM'),
(31, 1, 0, 0, 0, 0, 0, '11/30/2019 6:11:59 PM'),
(32, 1, 0, 0, 0, 0, 0, '11/30/2019 6:12:00 PM'),
(33, 1, 1, 1, 1, 1, 1, '11/30/2019 6:12:01 PM'),
(34, 1, 2, 2, 2, 2, 2, '11/30/2019 6:12:02 PM'),
(35, 1, 3, 3, 3, 3, 3, '11/30/2019 6:12:03 PM'),
(36, 1, 4, 4, 4, 4, 4, '11/30/2019 6:12:04 PM'),
(37, 1, 5, 5, 5, 5, 5, '11/30/2019 6:12:05 PM'),
(38, 1, 6, 6, 6, 6, 6, '11/30/2019 6:12:06 PM'),
(39, 1, 7, 7, 7, 7, 7, '11/30/2019 6:12:07 PM'),
(40, 1, 8, 8, 8, 8, 8, '11/30/2019 6:12:08 PM'),
(41, 1, 9, 9, 9, 9, 9, '11/30/2019 6:12:09 PM'),
(42, 1, 10, 10, 10, 10, 10, '11/30/2019 6:12:10 PM'),
(43, 1, 11, 11, 11, 11, 11, '11/30/2019 6:12:11 PM'),
(44, 1, 12, 12, 12, 12, 12, '11/30/2019 6:12:12 PM'),
(45, 1, 13, 13, 13, 13, 13, '11/30/2019 6:12:13 PM'),
(46, 1, 14, 14, 14, 14, 14, '11/30/2019 6:12:14 PM'),
(47, 1, 15, 15, 15, 15, 15, '11/30/2019 6:12:15 PM'),
(48, 1, 16, 16, 16, 16, 16, '11/30/2019 6:12:16 PM'),
(49, 1, 17, 17, 17, 17, 17, '11/30/2019 6:12:17 PM'),
(50, 1, 18, 18, 18, 18, 18, '11/30/2019 6:12:18 PM'),
(51, 1, 19, 19, 19, 19, 19, '11/30/2019 6:12:19 PM'),
(52, 1, 20, 20, 20, 20, 20, '11/30/2019 6:12:20 PM'),
(53, 1, 21, 21, 21, 21, 21, '11/30/2019 6:12:21 PM'),
(54, 1, 22, 22, 22, 22, 22, '11/30/2019 6:12:22 PM'),
(55, 1, 23, 23, 23, 23, 23, '11/30/2019 6:12:23 PM'),
(56, 1, 24, 24, 24, 24, 24, '11/30/2019 6:12:24 PM'),
(57, 1, 25, 25, 25, 25, 25, '11/30/2019 6:12:25 PM'),
(58, 1, 26, 26, 26, 26, 26, '11/30/2019 6:12:26 PM'),
(59, 1, 27, 27, 27, 27, 27, '11/30/2019 6:12:27 PM'),
(60, 1, 28, 28, 28, 28, 28, '11/30/2019 6:12:28 PM'),
(61, 1, 29, 29, 29, 29, 29, '11/30/2019 6:12:29 PM'),
(62, 1, 30, 30, 30, 30, 30, '11/30/2019 6:12:30 PM'),
(63, 1, 0, 0, 0, 0, 0, '11/30/2019 6:12:31 PM'),
(64, 1, 0, 0, 0, 0, 0, '11/30/2019 6:12:32 PM'),
(65, 1, 0, 0, 0, 0, 0, '11/30/2019 6:12:33 PM'),
(66, 1, 0, 0, 0, 0, 0, '11/30/2019 6:12:34 PM'),
(67, 1, 0, 0, 0, 0, 0, '11/30/2019 6:12:35 PM'),
(68, 1, 11, 11, 11, 11, 11, '11/30/2019 6:12:36 PM'),
(69, 1, 12, 12, 12, 12, 12, '11/30/2019 6:12:37 PM'),
(70, 1, 13, 13, 13, 13, 13, '11/30/2019 6:12:38 PM'),
(71, 1, 14, 14, 14, 14, 14, '11/30/2019 6:12:39 PM'),
(72, 1, 15, 15, 15, 15, 15, '11/30/2019 6:12:40 PM'),
(73, 1, 16, 16, 16, 16, 16, '11/30/2019 6:12:41 PM'),
(74, 1, 0, 0, 0, 0, 0, '11/30/2019 6:13:55 PM'),
(75, 1, 0, 0, 0, 0, 0, '11/30/2019 6:13:56 PM'),
(76, 1, 0, 0, 0, 0, 0, '11/30/2019 6:13:57 PM'),
(77, 1, 0, 0, 0, 0, 0, '11/30/2019 6:13:58 PM'),
(78, 1, 0, 0, 0, 0, 0, '11/30/2019 6:13:59 PM'),
(79, 1, 1, 1, 1, 1, 1, '11/30/2019 6:14:00 PM'),
(80, 2, 2, 2, 2, 2, 2, '11/30/2019 6:14:01 PM'),
(81, 1, 3, 3, 3, 3, 3, '11/30/2019 6:14:01 PM'),
(82, 2, 4, 4, 4, 4, 4, '11/30/2019 6:14:01 PM'),
(83, 1, 5, 5, 5, 5, 5, '11/30/2019 6:14:02 PM'),
(84, 2, 6, 6, 6, 6, 6, '11/30/2019 6:14:03 PM'),
(85, 1, 7, 7, 7, 7, 7, '11/30/2019 6:14:04 PM'),
(86, 2, 8, 8, 8, 8, 8, '11/30/2019 6:14:04 PM'),
(87, 1, 9, 9, 9, 9, 9, '11/30/2019 6:14:04 PM'),
(88, 2, 10, 10, 10, 10, 10, '11/30/2019 6:14:04 PM'),
(89, 1, 11, 11, 11, 11, 11, '11/30/2019 6:14:05 PM'),
(90, 2, 12, 12, 12, 12, 12, '11/30/2019 6:14:06 PM'),
(91, 1, 13, 13, 13, 13, 13, '11/30/2019 6:14:06 PM'),
(92, 2, 14, 14, 14, 14, 14, '11/30/2019 6:14:07 PM'),
(93, 1, 15, 15, 15, 15, 15, '11/30/2019 6:14:07 PM'),
(94, 2, 16, 16, 16, 16, 16, '11/30/2019 6:14:08 PM'),
(95, 1, 17, 17, 17, 17, 17, '11/30/2019 6:14:08 PM'),
(96, 2, 18, 18, 18, 18, 18, '11/30/2019 6:14:08 PM'),
(97, 1, 19, 19, 19, 19, 19, '11/30/2019 6:14:09 PM'),
(98, 2, 20, 20, 20, 20, 20, '11/30/2019 6:14:10 PM'),
(99, 1, 21, 21, 21, 21, 21, '11/30/2019 6:14:10 PM'),
(100, 2, 22, 22, 22, 22, 22, '11/30/2019 6:14:11 PM'),
(101, 1, 23, 23, 23, 23, 23, '11/30/2019 6:14:11 PM'),
(102, 2, 24, 24, 24, 24, 24, '11/30/2019 6:14:11 PM'),
(103, 1, 25, 25, 25, 25, 25, '11/30/2019 6:14:12 PM'),
(104, 2, 26, 26, 26, 26, 26, '11/30/2019 6:14:13 PM'),
(105, 1, 27, 27, 27, 27, 27, '11/30/2019 6:14:13 PM'),
(106, 2, 28, 28, 28, 28, 28, '11/30/2019 6:14:13 PM'),
(107, 1, 29, 29, 29, 29, 29, '11/30/2019 6:14:14 PM'),
(108, 2, 30, 30, 30, 30, 30, '11/30/2019 6:14:15 PM'),
(109, 1, 0, 0, 0, 0, 0, '11/30/2019 6:14:15 PM'),
(110, 2, 0, 0, 0, 0, 0, '11/30/2019 6:14:16 PM'),
(111, 1, 0, 0, 0, 0, 0, '11/30/2019 6:14:16 PM'),
(112, 2, 0, 0, 0, 0, 0, '11/30/2019 6:14:16 PM'),
(113, 1, 0, 0, 0, 0, 0, '11/30/2019 6:14:17 PM'),
(114, 2, 11, 11, 11, 11, 11, '11/30/2019 6:14:18 PM'),
(115, 1, 12, 12, 12, 12, 12, '11/30/2019 6:14:18 PM'),
(116, 2, 13, 13, 13, 13, 13, '11/30/2019 6:14:19 PM'),
(117, 1, 14, 14, 14, 14, 14, '11/30/2019 6:14:19 PM'),
(118, 2, 15, 15, 15, 15, 15, '11/30/2019 6:14:19 PM'),
(119, 1, 16, 16, 16, 16, 16, '11/30/2019 6:14:20 PM'),
(120, 2, 17, 17, 17, 17, 17, '11/30/2019 6:14:21 PM'),
(121, 1, 18, 18, 18, 18, 18, '11/30/2019 6:14:21 PM'),
(122, 2, 19, 19, 19, 19, 19, '11/30/2019 6:14:22 PM'),
(123, 1, 20, 20, 20, 20, 20, '11/30/2019 6:14:22 PM'),
(124, 2, 0, 0, 0, 0, 0, '11/30/2019 6:14:23 PM'),
(125, 1, 0, 0, 0, 0, 0, '11/30/2019 6:14:23 PM'),
(126, 2, 0, 0, 0, 0, 0, '11/30/2019 6:14:24 PM'),
(127, 1, 0, 0, 0, 0, 0, '11/30/2019 6:14:24 PM'),
(128, 2, 0, 0, 0, 0, 0, '11/30/2019 6:14:25 PM');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bedside`
--
ALTER TABLE `bedside`
  ADD PRIMARY KEY (`bedsideId`);

--
-- Indexes for table `medicalstaff`
--
ALTER TABLE `medicalstaff`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `modulesreading`
--
ALTER TABLE `modulesreading`
  ADD PRIMARY KEY (`modulesReadingId`);

--
-- Indexes for table `onshift`
--
ALTER TABLE `onshift`
  ADD PRIMARY KEY (`onShiftId`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`patientId`);

--
-- Indexes for table `patientreadings`
--
ALTER TABLE `patientreadings`
  ADD PRIMARY KEY (`patientReadingId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bedside`
--
ALTER TABLE `bedside`
  MODIFY `bedsideId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;

--
-- AUTO_INCREMENT for table `medicalstaff`
--
ALTER TABLE `medicalstaff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `modulesreading`
--
ALTER TABLE `modulesreading`
  MODIFY `modulesReadingId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `onshift`
--
ALTER TABLE `onshift`
  MODIFY `onShiftId` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `patient`
--
ALTER TABLE `patient`
  MODIFY `patientId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `patientreadings`
--
ALTER TABLE `patientreadings`
  MODIFY `patientReadingId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=129;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
