using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contract.Utility.Transactions
{
    /// <summary>
    /// Indicates the possible values for a transaction result
    /// </summary>
    public enum Result { ERROR, SUCCESS, WARNING }

    /// <summary>
    /// Used to set messages and share them through transactions
    /// </summary>
    public class MessageDetail
    {
        /// <summary>
        /// ERROR, SUCCESS, WARNING
        /// </summary>
        public Result type;
        /// <summary>
        /// Stores an ID for the transaction that was executed
        /// </summary>
        public String key;
        /// <summary>
        /// Contains the message result of tyhe transaction execution
        /// </summary>
        public String message;
        /// <summary>
        /// Contains the message detail result of tyhe transaction execution
        /// </summary>
        public String messageDetail;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MessageDetail()
        {
        }
        /// <summary>
        /// Constructor with fields
        /// </summary>
        /// <param name="key">Message identifier. It can be a code, serial number, etc.</param>
        /// <param name="message">Actual message to store, in short format</param>
        /// <param name="messageDetail">Extended/detailed message. It can be an exception text</param>
        public MessageDetail(String key, String message, String messageDetail)
        {
            this.key = key;
            this.message = message;
            this.messageDetail = messageDetail;
        }
        /**
         * Create a SUCCESS instance
         *
         * @param key
         *            Message identifier. It can be a code, serial number, etc.
         * @param message
         *            Actual message to store, in short format
         * @param messageDetail
         *            Extended/detailed message. It can be an exception text
         *
         * @return New Message Detail Instance
         */
        public static MessageDetail CreateSuccessMessage(String key, String message, String messageDetail)
        {
            MessageDetail m = new MessageDetail(key, message, messageDetail);
            m.SetType(Result.SUCCESS);
            return m;
        }
        /**
         * Create an ERROR instance
         *
         * @param key
         *            Message identifier. It can be a code, serial number, etc.
         * @param message
         *            Actual message to store, in short format
         * @param messageDetail
         *            Extended/detailed message. It can be an exception text
         *
         * @return New Message Detail Instance
         */
        public static MessageDetail CreateErrorMessage(String key, String message, String messageDetail)
        {
            MessageDetail m = new MessageDetail(key, message, messageDetail);
            m.SetType(Result.ERROR);
            return m;
        }
        /**
         * Create a WARNING instance
         *
         * @param key
         *            Message identifier. It can be a code, serial number, etc.
         * @param message
         *            Actual message to store, in short format
         * @param messageDetail
         *            Extended/detailed message. It can be an exception text
         *
         * @return New Message Detail Instance
         */
        public static MessageDetail CreateWarningMessage(String key, String message, String messageDetail)
        {
            MessageDetail m = new MessageDetail(key, message, messageDetail);
            m.SetType(Result.WARNING);
            return m;
        }
        /**
         * Gets the message key / identifier. It can be a serial number, process,
         * etc.
         *
         * @return the key
         */
        public String GetKey()
        {
            return key;
        }
        /**
         * Gets the message. This message is intended to be a short description /
         * code
         *
         * @return the message
         */
        public String GetMessage()
        {
            return message;
        }
        /**
         * Gets the detailed message description. It can be an exception message, a
         * list of constraints that failed, etc.
         *
         * @return the detailed message
         */
        public String GetMessageDetail()
        {
            return messageDetail;
        }
        /**
         * Gets the message type. It can be successful / error / warning
         *
         * @return the message type
         */
        public Result GetResultType()
        {
            return type;
        }
        /**
         * Sets the key
         *
         * @param key
         *            Value to set
         */
        public void SetKey(String key)
        {
            this.key = key;
        }
        /**
         * Sets the message
         *
         * @param message
         *            Value to set
         */
        public void SetMessage(String message)
        {
            this.message = message;
        }
        /**
         * Sets the message detail
         *
         * @param messageDetail
         *            Value to set
         */
        public void SetMessageDetail(String messageDetail)
        {
            this.messageDetail = messageDetail;
        }
        /**
         * Sets the message type
         *
         * @param type
         *            Value to set
         */
        public void SetType(Result type)
        {
            this.type = type;
        }
        /**
         * Evaluates if message is SUCCESS
         *
         * @return True for successful messages. False otherwise
         */
        public bool IsSuccess()
        {
            return type == Result.SUCCESS;
        }
        /**
         * Evaluates if message is ERROR
         *
         * @return True for error messages. False otherwise
         */
        public bool IsError()
        {
            return type == Result.ERROR;
        }
        /**
         * Evaluates if message is WARNING
         *
         * @return True for warning messages. False otherwise
         */
        public bool IsWarning()
        {
            return type == Result.WARNING;
        }
        /**
         * Creates serializable representation of the message
         *
         * @return Message data as a String
         */
        public String ToHtml()
        {
            String typeStr = "";
            switch (type)
            {
                case Result.SUCCESS:
                    typeStr = "SUCCESS";
                    break;
                case Result.ERROR:
                    typeStr = "ERROR";
                    break;
                case Result.WARNING:
                    typeStr = "WARNING";
                    break;
                default:
                    typeStr = "";
                    break;
            }
            return "<tr><td>" + typeStr + "</td><td>" + key + "</td><td>" + message + "</td><td>" + messageDetail + "</td>";
        }
    }
}
