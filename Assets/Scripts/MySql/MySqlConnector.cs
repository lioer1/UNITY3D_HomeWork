using System;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//如果只是在本地的话，写localhost就可以。
//如果是局域网，那么写上本机的局域网IP
// static string host = "localhost";
// static string port = "3306";
// static string username = "root";
// static string pwd = "root";
// static string database = "test";

public class MySqlConnector : MonoBehaviour
{
    
    private static MySqlConnector instance;
    //1.定义 字符串组
    protected static string ip = "127.0.0.1";       //定义 服务器IP
    protected static string port = "3306";          //定义 端口
    protected static string database = "test"; //定义 数据库
    protected static string user = "root";          //定义 用户名
    protected static string mypassword = "123456";  //定义 密码
    public static MySqlConnector Instance => instance;
    
    public static MySqlConnection dbConnection;

    private string account;
    private string password;
    
    
  


    private void Awake()
    {
        instance = this ;
        OpenSql();
        DontDestroyOnLoad(this.gameObject);
    }

   

    /// <summary>
    /// 连接数据库
    /// </summary>
    public static void OpenSql()
    {
        
        try
        {
            string connectionString = string.Format("server={0};port={1};database={2};user={3};password={4};allowuservariables=true", ip, port, database, user, mypassword);
            Debug.Log(connectionString);
            dbConnection = new MySqlConnection(connectionString);
            dbConnection.Open();
            Debug.Log("建立连接");
        }
        catch (Exception e)
        {
            throw new Exception("服务器连接失败，请重新检查是否打开MySql服务。" + e.Message.ToString());
        }
    }
	
    /// <summary>
    /// 关闭数据库连接
    /// </summary>
    public void Close()
    {
        if (dbConnection != null)
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dbConnection = null;
        }
    }

    public bool CheckAccount(string a, string p)
    {
       
        bool accountExists = true;
        string query = "SELECT COUNT(*) FROM user WHERE account = @account AND password = @password";
        MySqlCommand cmd = new MySqlCommand(query, dbConnection);
        cmd.Parameters.AddWithValue("@account", a);
        cmd.Parameters.AddWithValue("@password", p);
        int count = Convert.ToInt32(cmd.ExecuteScalar());
        Debug.Log(count);
        if ( count <=0)
        { 
            accountExists=false;
        }

        this.account = a;
        this.password = p;
        return accountExists;
    }

    public int Count()
    {
        
        string query = "SELECT COUNT(*) FROM user";
        MySqlCommand cmd = new MySqlCommand(query, dbConnection);

       return Convert.ToInt32(cmd.ExecuteScalar());
    }


    public void SaveGrade(int grade)
    {
        string query = "UPDATE user SET grade = @grade WHERE account =  @account AND password = @password";
        MySqlCommand cmd = new MySqlCommand(query, dbConnection);
        cmd.Parameters.AddWithValue("@grade", grade);
        cmd.Parameters.AddWithValue("@account", this.account);
        cmd.Parameters.AddWithValue("@password", this.password);
        int rowsAffected = cmd.ExecuteNonQuery();
        Debug.Log(rowsAffected > 0 ? "Grade updated successfully." : "No matching records found.");
    }

}
