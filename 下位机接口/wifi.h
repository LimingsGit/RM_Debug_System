#ifndef __WIFI_H
#define __WIFI_H	 
#include "delay.h"

//基地
#define VEHICLE_TYPE_MATRIX 1
//英雄车
#define VEHICLE_TYPE_HERO 2
//工程车
#define VEHICLE_TYPE_ENGINEER 3
//补给站
#define VEHICLE_TYPE_DEPOT 4
//步兵车1
#define VEHICLE_TYPE_PACER_1 5
//步兵车2
#define VEHICLE_TYPE_PACER_2 6
//步兵车3
#define VEHICLE_TYPE_PACER_3 7

//车的connect_id
#define DATA_PART_1_LENGTH 6
//底盘电机12的电流、速度、功率信息
#define DATA_PART_2_LENGTH 11
//底盘电机34的电流、速度、功率信息
#define DATA_PART_3_LENGTH 11
//云台yaw轴和pitch电机的电流、速度、位置信息
#define DATA_PART_4_LENGTH 11
//拨弹电机的电流、速度、位置信息+摩擦轮电机的电流、速度信息
#define DATA_PART_5_LENGTH 12

//简单的PID结构体
typedef struct{
	float kp;
	float ki;
	float kd;
}Simple_PID_TypeDef;

//电机状态信息结构体
typedef struct{
	float i;//电流
	float v;//速度
	float s;//位置
	float p;//功率
}Motor_Condition_TypeDef;

//步兵车状态信息结构体
typedef struct 
{
	//底盘电机1状态信息
	Motor_Condition_TypeDef chassis_motor1_condition;
	//底盘电机2状态信息
	Motor_Condition_TypeDef chassis_motor2_condition;
	//底盘电机3状态信息
	Motor_Condition_TypeDef chassis_motor3_condition;
	//底盘电机4状态信息
	Motor_Condition_TypeDef chassis_motor4_condition;
	//云台电机yaw轴状态信息
	Motor_Condition_TypeDef cradle_yaw_motor_condition;
	//云台电机pitch轴状态信息
	Motor_Condition_TypeDef cradle_pitch_motor_condition;
	//拨弹电机状态信息
	Motor_Condition_TypeDef rammer_motor_condition;
	//摩擦轮电机1状态信息
	Motor_Condition_TypeDef shooter1_motor_condition;
	//摩擦轮电机2状态信息
	Motor_Condition_TypeDef shooter2_motor_condition;
}Pacer_Vehicle_Condition_TypeDef;
//////////////////////////////////////////////////////////////////////////////////	 

////////////////////////////////////////////////////////////////////////////////// 

void init_Wifi(u8,char*);//初始化
void send_WifiData(char*);
void printNewLine(void);
//更新wifi发送标识，在中断中每1ms调用一次
void update_wifi_send_flag(void);
//发送整车所有电机状态信息至上位机
void send_motor_conditions(Motor_Condition_TypeDef* chassis_motor1_condition
	,Motor_Condition_TypeDef* chassis_motor2_condition
	,Motor_Condition_TypeDef* chassis_motor3_condition
	,Motor_Condition_TypeDef* chassis_motor4_condition
	,Motor_Condition_TypeDef* cradle_yaw_motor_condition
	,Motor_Condition_TypeDef* cradle_pitch_motor_condition
	,Motor_Condition_TypeDef* rammer_motor_condition
	,Motor_Condition_TypeDef* shooter1_motor_condition
	,Motor_Condition_TypeDef* shooter2_motor_condition
	);
//取得初始化的电机状态信息结构体
Motor_Condition_TypeDef get_default_motor_conditon(void);
//取得初始化的步兵车状态信息结构体
Pacer_Vehicle_Condition_TypeDef get_default_pacer_vehicle_conditon(void);
//发送步兵车状态信息至上位机
void send_pacer_vihecle_condition(Pacer_Vehicle_Condition_TypeDef* pacer_vehicle_condition);
//在main函数中以最高频率调用
void always_send(void);
//处理收到的connect_id
void handle_connect_id(u8 id);   
//处理收到的底盘电机1的电流环、速度环、功率环pid参数
void handle_chassis_motor1_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//处理收到的底盘电机2的电流环、速度环、功率环pid参数
void handle_chassis_motor2_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//处理收到的底盘电机3的电流环、速度环、功率环pid参数
void handle_chassis_motor3_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//处理收到的底盘电机4的电流环、速度环、功率环pid参数
void handle_chassis_motor4_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_p);
//处理收到的云台yaw轴电机的电流环、速度环、位置环pid参数
void handle_cradle_yaw_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s);
//处理收到的云台pitch轴电机的电流环、速度环、位置环pid参数
void handle_cradle_pitch_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s);
//处理收到的拨弹电机的电流环、速度环、位置环pid参数
void handle_rammer_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v,Simple_PID_TypeDef* pid_s);
//处理收到的摩擦轮电机1的电流环、速度环参数
void handle_shooter1_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v);
//处理收到的摩擦轮电机2的电流环、速度环参数
void handle_shooter2_motor_pid(Simple_PID_TypeDef* pid_i,Simple_PID_TypeDef* pid_v);

#endif
